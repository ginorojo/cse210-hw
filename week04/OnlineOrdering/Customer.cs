public class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool IsInUS()
    {
        return address.IsInUS();
    }

    public string GetInfo()
    {
        return $"{name}\n{address.GetFullAddress()}";
    }
}