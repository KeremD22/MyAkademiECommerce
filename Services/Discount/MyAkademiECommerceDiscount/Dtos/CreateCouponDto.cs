namespace MyAkademiECommerceDiscount.Dtos
{
    public class CreateCouponDto
    {
       
        public string Code { get; set; }
        public int Rate { get; set; }
        public DateTime ValidDate { get; set; }
        public bool IsActive { get; set; }
    }
}
