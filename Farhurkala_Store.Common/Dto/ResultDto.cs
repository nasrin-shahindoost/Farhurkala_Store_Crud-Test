using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farhurkala_Store.Common.Dto
{
    //چون این دوتا فیلد را در خیلی از جاها نیاز داریم پس بهتر است در یک کلاس قرار دهیم.
  public class ResultDto
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }
    }

    // در این می توانیم یه کلاس یا دی تی ا دیگه هم بهش پاس بدیم و اون را درقالب دیتا ست کنه
    //برای مثال آی دی کاربرثبت نام شده
    public class ResultDto<T>
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }
    }
}
