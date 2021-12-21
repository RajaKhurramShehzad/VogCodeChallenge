using System;

namespace VogCodeChallengeTask8
{
    public class SwitchStatementClass
    {
        public T TESTModule<T>(ref T intPut)
        {
            object ret;
            switch (typeof(T) == typeof(int)  && Convert.ToInt32(intPut) >= 1 && Convert.ToInt32(intPut) <= 4 ? "IntergerGreatherThen1LessThen4" :
                    typeof(T) == typeof(int) && Convert.ToInt32(intPut) > 4 ? "IntergerGreaterThen4" :
                    typeof(T) == typeof(int) && Convert.ToInt32(intPut) < 1 ? "IntegerLessThen1" :
                    typeof(T) == typeof(float) && Convert.ToDouble(intPut) == 1.0f  ? "Float1.0f" :
                    typeof(T) == typeof(float) && Convert.ToDouble(intPut) == 2.0f ? "Float2.0f" :
                    typeof(T) == typeof(string) ? "String" :
                    "Other")
            {
                case "IntergerGreatherThen1LessThen4":
                    ret = Convert.ToInt32(intPut) * 2;
                    break;
                case "IntergerGreaterThen4":
                    ret = Convert.ToInt32(intPut) * 3;
                    break;
                case "IntegerLessThen1":
                    throw new Exception("Exception as value is less then 1");
                    break;
                case "Float1.0f":
                    ret = 3.0f;
                    break;
                case "Float2.0f":
                    ret = 3.0f;
                    break;
                case "String":
                    ret = intPut.ToString().ToUpper();
                    break;
                default:
                    ret = intPut;
                    break;;
            }

            return (T)Convert.ChangeType(ret, typeof(T));
        }
    }
}
