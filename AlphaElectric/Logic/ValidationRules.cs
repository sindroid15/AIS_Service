using System;
using System.Globalization;
using System.Windows.Controls;

namespace AIS.Logic
{
    public class NotEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return string.IsNullOrWhiteSpace((value ?? "").ToString())
                ? new ValidationResult(false, "Обязательное поле.")
                : ValidationResult.ValidResult;
        }
    }

    public class FutureDateValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (!DateTime.TryParse((value ?? "").ToString(),
                CultureInfo.CurrentCulture,
                DateTimeStyles.AssumeLocal | DateTimeStyles.AllowWhiteSpaces,
                out var time))
            {
                return new ValidationResult(false, "Некорректные данные");
            }

            return time.Date <= DateTime.Now.Date
                ? new ValidationResult(false, "Требуется дата следующих дней")
                : ValidationResult.ValidResult;
        }
    }

    public class PresentFutureDateValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (!DateTime.TryParse((value ?? "").ToString(),
                CultureInfo.CurrentCulture,
                DateTimeStyles.AssumeLocal | DateTimeStyles.AllowWhiteSpaces,
                out var time))
            {
                return new ValidationResult(false, "Некорректные данные");
            }

            return time.Date <= DateTime.Now.Date.AddDays(-1)
                ? new ValidationResult(false, "Требуются сегодняшнее число или последующие дни")
                : ValidationResult.ValidResult;
        }
    }

    public class PastDateValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (!DateTime.TryParse((value ?? "").ToString(),
                CultureInfo.CurrentCulture,
                DateTimeStyles.AssumeLocal | DateTimeStyles.AllowWhiteSpaces,
                out var time))
            {
                return new ValidationResult(false, "Некорректные данные");
            }

            return time.Date >= DateTime.Now.Date.AddDays(1) 
                ? new ValidationResult(false, "Требуются сегодняшнее число или предыдущие дни")
                : ValidationResult.ValidResult;
        }
    }
}
