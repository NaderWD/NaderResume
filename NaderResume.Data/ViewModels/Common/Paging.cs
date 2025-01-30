namespace NaderResume.Data.ViewModels.Common
{
    public class BasePaging<T>
    {
        public BasePaging()
        {
            Page = 1;
            TakeEntity = 10;
            HowManyPagesShowAfterAndBefore = 5;
            Entities = new List<T>();
        }

        public int Page { get; set; }
        public int PageCount { get; set; }
        public int AllEntitiesCount { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int TakeEntity { get; set; }
        public int SkipEntity { get; set; }
        public int HowManyPagesShowAfterAndBefore { get; set; }
        public List<T> Entities { get; set; }


        public PagingViewModel GetCurrentPaging()
        {
            return new PagingViewModel
            {
                EndPage = EndPage,
                Page = Page,
                StartPage = StartPage,
                PageCount = PageCount
            };
        }



        public async Task<BasePaging<T>> Paging(IQueryable<T> queryable)
        {
            var takeEntity = TakeEntity;
            var allEntitiesCount = queryable.Count();
            var howManyPagesShowAfterAndBefore = HowManyPagesShowAfterAndBefore;
            var pageCount = 0;

            try
            {
                pageCount = Convert.ToInt32(allEntitiesCount / (double)takeEntity);
            }
            catch (Exception)
            {

            }

            Page = Page > pageCount ? pageCount : Page;
            if (Page <= 0) Page = 1;
            AllEntitiesCount = allEntitiesCount;
            SkipEntity = (Page - 1) * TakeEntity;
            StartPage = Page - howManyPagesShowAfterAndBefore <= 0 ? 1 : Page - howManyPagesShowAfterAndBefore;
            EndPage = Page + howManyPagesShowAfterAndBefore <= pageCount ? pageCount : Page + howManyPagesShowAfterAndBefore;
            PageCount = pageCount;
            Entities = await Task.Run(() => queryable.Skip(SkipEntity).Take(TakeEntity).ToList());

            return this;
        }
        public BasePaging<T> Paging()
        {
            var allEntitiesCount = Entities.Count;
            var howManyPagesShowAfterAndBefore = HowManyPagesShowAfterAndBefore;
            var pageCount = 0;

            try
            {
                pageCount = Convert.ToInt32(Math.Ceiling(allEntitiesCount / (double)TakeEntity));
            }
            catch (Exception)
            {

            }

            Page = Page > pageCount ? pageCount : 1;
            if (Page <= 0) Page = 0;
            AllEntitiesCount = allEntitiesCount;
            HowManyPagesShowAfterAndBefore = howManyPagesShowAfterAndBefore;
            StartPage = Page - howManyPagesShowAfterAndBefore <= 0 ? 1 : Page - howManyPagesShowAfterAndBefore;
            EndPage = Page + howManyPagesShowAfterAndBefore <= pageCount ? pageCount : Page + howManyPagesShowAfterAndBefore;
            PageCount = pageCount;

            return this;
        }
    }
    public class PagingViewModel
    {
        public int Page { get; set; }
        public int PageCount { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
    }
}
