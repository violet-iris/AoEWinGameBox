namespace AoE4GameBox.Common
{
    public class Result
    {
        // 返回约定数值，通知前端是否成功
        public string Code { get; private set; }

        // 返回携带信息
        public string Msg { get; private set; }

        // 返回数据
        public object Data { get; private set; }

        // 无参数构造函数
        public Result()
        {
            Code = "default";
            Msg = "default";
            Data = "default";
        }

        // 全参数构造函数
        public Result(string code, string msg, object data)
        {
            Code = code;
            Msg = msg;
            Data = data;
        }

        // 成功的静态方法（无数据）
        public static Result Success()
        {
            return new Result(IConstants.CODE_200, "IConstants.CODE_200", "");
        }

        // 成功的静态方法（带数据）
        public static Result Success(object data)
        {
            return new Result(IConstants.CODE_200, "IConstants.CODE_200", data);
        }

        // 错误的静态方法（权限不足）
        public static Result Error(string msg)
        {
            return new Result(IConstants.CODE_400, msg, "");
        }

        // 错误的静态方法
        public static Result Error(string code, string msg)
        {
            return new Result(code, msg, "");
        }

        // 默认错误的静态方法
        public static Result Error()
        {
            return new Result(IConstants.CODE_500, "系统错误", "");
        }
    }
}
