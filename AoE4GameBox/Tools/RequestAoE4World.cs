using AoE4GameBox.Common;
using AoE4GameBox.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Windows.Media.AppBroadcasting;

namespace AoE4GameBox.Tools
{
    internal class RequestAoE4World
    {
        /// <summary>
        /// 搜索玩家基础信息 返回Player类
        /// </summary>
        internal static async Task<Player> GetPlayerClassBySearch(string TextSearch)
        {
            Result rePlayerInfo = await RequestAoE4World.GetPlayerInfo(TextSearch);
            if (rePlayerInfo.Code == IConstants.CODE_200)
            {
                // 解析JSON
                JsonDocument jsonDoc = JsonDocument.Parse((string)rePlayerInfo.Data);
                JsonElement rootElement = jsonDoc.RootElement;
                // 根据JSON结构进行操作 提取字符串字段
                var PlayerName = rootElement.GetProperty("name").GetString() ?? "Default";
                var PlayerProfileId = rootElement.GetProperty("profile_id").GetInt32();
                var PlayerSteamId = rootElement.GetProperty("steam_id").GetString() ?? "Default";
                var PlayerSiteUrl = rootElement.GetProperty("site_url").GetString() ?? "Default";
                var StrAvatarSmall = rootElement.GetProperty("avatars").GetProperty("small").GetString();
                var StrAvatarMedium = rootElement.GetProperty("avatars").GetProperty("medium").GetString();
                var StrAvatarFull = rootElement.GetProperty("avatars").GetProperty("full").GetString();
                var PlayerAvatars = new Avatar(StrAvatarSmall, StrAvatarMedium, StrAvatarFull);
                var PlayerCountryArea = rootElement.GetProperty("country").GetString() ?? "Default";

                var PlayerInfo = new Player(PlayerName, PlayerProfileId, PlayerSteamId, PlayerCountryArea, PlayerSiteUrl, PlayerAvatars);

                return PlayerInfo;

            } else
            {
                Logger.Error("玩家档案编号 (游戏ID) 未找到");
                Logger.Error("rePlayerInfo.Code :", $"{rePlayerInfo.Code}");
                Logger.Error("rePlayerInfo.Msg :", $"{rePlayerInfo.Msg}");
                return new Player();
            }
        }

        internal static async Task<Result> GetPlayerInfo(string text_search)
        {
            // 精确搜索
            Result res = await SearchAdvancedPlayer(text_search);
            if (res.Code == IConstants.CODE_200)
            {
                return res;
            }
            // 模糊搜索
            res = await SearchFuzzyPlayer(text_search);
            if (res.Code == IConstants.CODE_200)
            {
                string playerInfo = ExtractPlayerInfo(res.Data);
                return Result.Success(playerInfo);
            }
            Logger.Log("玩家档案未找到");
            return res;
        }

        // 精确搜索
        internal static async Task<Result> SearchAdvancedPlayer(string str)
        {
            string url = $"https://aoe4world.com/api/v0/players/{str}";
            return await Request.RequestURL(url);
        }

        // 模糊搜索
        internal static async Task<Result> SearchFuzzyPlayer(string str)
        {
            string url = $"https://aoe4world.com/api/v0/players/search?query={str}" + @"&exact=false";
            return await Request.RequestURL(url);
        }

        // 模糊搜索的结果中提取玩家信息
        private static string ExtractPlayerInfo(object data)
        {
            JsonDocument jsonDocument = JsonDocument.Parse((string)data);
            JsonElement rootElement = jsonDocument.RootElement.GetProperty("players");
            string playerInfo = rootElement[0].ToString();
            return playerInfo;
        }

        public static async Task<Result> GetPlayerLastGame(string str_player_id)
        {
            string url = "https://aoe4world.com/api/v0/players/" + str_player_id +"/games/last";
            try
            {
                Logger.Info(url);
                using HttpClient client = new();
                Task<HttpResponseMessage> responseTask = client.GetAsync(url);
                responseTask.Wait();
                if (responseTask.Result.IsSuccessStatusCode)
                {
                    string responseBody = await responseTask.Result.Content.ReadAsStringAsync();
                    // 输出网页内容
                    // 使用Newtonsoft.Json解析JSON
                    JObject jsonObject = JObject.Parse(responseBody);
                    // 日志记录根元素
                    Logger.Info(jsonObject);

                    // 提取字符串字段
                    string GameId = (string)jsonObject["game_id"];
                    // TODO：继续提取其他字段
                    string str_map = (string)jsonObject["map"];
                    string str_leaderboard = (string)jsonObject["leaderboard"];

                    // 将 JSON 数据转换为 List<OverlayGame>
                    List<GameLast> teamList = [];
                    int index = 0;
                    foreach (JToken outerToken in jsonObject["teams"])
                    {
                        foreach (JToken innerToken in outerToken)
                        {
                            // 处理 innerToken 并创建 OverlayGame 对象
                            OverlayGame ObjectOverlayGame = new OverlayGame
                            {
                                Map = str_map,
                                Leaderboard = str_leaderboard,
                                TeamNumber = index,
                                PlayerName = innerToken["name"]?.ToString() ?? "default",
                                PlayerCiv = innerToken["civilization"]?.ToString() ?? "default",
                                Rating = innerToken["modes"][str_leaderboard]["rating"]?.ToString(),
                                Rank = innerToken["modes"][str_leaderboard]["rank"]?.ToString(),
                                Winrate = innerToken["modes"][str_leaderboard]["win_rate"]?.ToString(),
                                Wins = innerToken["modes"][str_leaderboard]["wins_count"]?.ToString(),
                                Losses = innerToken["modes"][str_leaderboard]["losses_count"]?.ToString()
                            };
                        }
                        index++;
                    }
                    Result result = Result.Success(teamList);
                    return result;
                } else
                {
                    Logger.Log("玩家未找到");
                    Logger.Log($"Request failed with status code : ${responseTask.Result.StatusCode}");
                    Result result = Result.Error($"玩家未找到 " +
                        $"Request failed with status code : ${responseTask.Result.StatusCode}");
                    return result;
                }
            } catch (Exception ex)
            {
                Logger.Log("Exception ex", ex.ToString());
                Result result = Result.Error(IConstants.CODE_500, "查询系统异常");
                return result;
            }
        }

        internal static async Task<Result> GetLatestGame(string str_player_id)
        {
            // TODO: 继续解耦合
            string url = $"https://aoe4world.com/api/v0/players/{str_player_id}/games/last";
            try
            {
                Logger.Log(url);
                // 创建HttpClient对象
                using HttpClient client = new();
                // 发送GET请求
                Task<HttpResponseMessage> responseTask = client.GetAsync(url);
                responseTask.Wait();
                // 获取响应内容
                if (responseTask.Result.IsSuccessStatusCode)
                {
                    string responseBody = await responseTask.Result.Content.ReadAsStringAsync();
                    // 输出网页内容
                    // 解析JSON
                    JsonDocument jsonDocument = JsonDocument.Parse(responseBody);
                    JsonElement rootElement = jsonDocument.RootElement;
                    Logger.Log(rootElement);
                    // 根据JSON结构进行操作
                    // 提取字符串字段
                    // 获取地图和对应排行榜
                    var str_map = rootElement.GetProperty("map").GetString() ?? "default";
                    var str_leaderboard = rootElement.GetProperty("leaderboard").GetString() ?? "default";

                    // 将 JSON 数据转换为 List<OverlayGame>
                    List<OverlayGame> teamList = [];
                    int index = 0;
                    foreach (JsonElement outerElement in rootElement.GetProperty("teams").EnumerateArray())
                    {
                        foreach (JsonElement innerElement in outerElement.EnumerateArray())
                        {
                            // 在这里处理 innerElement 并创建 OverlayGame 对象
                            // 然后将对象添加到 innerList
                            // 创建 OverlayGame 对象并添加到 innerList
                            OverlayGame ObjectOverlayGame = new()
                            {
                                Map = str_map,
                                Leaderboard = str_leaderboard,
                                TeamNumber = index,
                                PlayerName = innerElement.GetProperty("name").GetString() ?? "default",
                                PlayerCiv = innerElement.GetProperty("civilization").GetString() ?? "default",
                                Rating = innerElement.GetProperty("modes").GetProperty(str_leaderboard).GetProperty("rating").GetRawText(),
                                Rank = innerElement.GetProperty("modes").GetProperty(str_leaderboard).GetProperty("rank").GetRawText(),
                                Winrate = innerElement.GetProperty("modes").GetProperty(str_leaderboard).GetProperty("win_rate").GetRawText(),
                                Wins = innerElement.GetProperty("modes").GetProperty(str_leaderboard).GetProperty("wins_count").GetRawText(),
                                Losses = innerElement.GetProperty("modes").GetProperty(str_leaderboard).GetProperty("losses_count").GetRawText()
                            };
                            teamList.Add(ObjectOverlayGame);
                        }
                        index++;
                    }
                    Result result = Result.Success(teamList);
                    return result;
                } else
                {
                    Logger.Log("玩家未找到");
                    Logger.Log($"Request failed with status code : ${responseTask.Result.StatusCode}");
                    Result result = Result.Error($"玩家未找到 " +
                        $"Request failed with status code : ${responseTask.Result.StatusCode}");
                    return result;
                }
            } catch (Exception ex)
            {
                Logger.Log("Exception ex", ex.ToString());
                Result result = Result.Error(IConstants.CODE_500, "查询系统异常");
                return result;
            }
        }
    }
}
