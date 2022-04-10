using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farhurkala_Store.Common
{
   public static class Pagination
    {
        //این متد یک تی سورس می گیره که یک کوئری می باشد و یعنی از دیتابیس یه چیزی می خونه
        // page شماره صفحه ای که می خوایم برای ما برگشت داده بشه
        //pagesize یعنی در هر صفحه چندتا رکورد را می خوایم نمایش بدیم
        //rowsCount یک خروجی که تعدادکل رکوردهارا برای مانمایش میده
        public static IEnumerable<TSource> ToPaged<TSource>(this IEnumerable<TSource> source,int page,int pageSize,out int rowsCount)
        {
            rowsCount = source.Count();
            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}
