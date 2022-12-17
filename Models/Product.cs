public partial class Product
{
    public Product(){

    }
    public int? idPro {get; set;}
    public string? name {get; set;}
    public string? description {get; set;}
    public int price {get; set;}

    public virtual int? idLot {get; set;}
    public virtual int idProSta {get; set;}
    public virtual int? idWer {get; set;}

}