using Domain;
using Microsoft.Data.SqlClient;

namespace DataAccess.SqlServer;

public class FlowerDao : BaseDao
{
    public IList<Flower> GetFlowers()
    {
        using (SqlConnection con = GetConnection())
        {
            con.Open();
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "select FlowerID, Name, Color, Price  from dbo.Flowers order by FlowerID";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    IList<Flower> flowers = new List<Flower>();
                    while (reader.Read())
                    {
                        Flower flower = new(reader.GetInt32(0),  reader.GetString(1), reader.GetString(2), reader.GetDecimal(3));
                        flowers.Add(flower);
                    }
                    return flowers;
                }
            }
        }
    }
    
    // public void AddFlower(Flower flower)
    // {
    //     using (SqlConnection con = GetConnection())
    //     {
    //         con.Open();
    //         using (SqlCommand cmd = con.CreateCommand())
    //         {
    //             cmd.CommandText = "insert into dbo.Flowers(Name, Color, Price) values (@Name, @Color, @Price);";
    //             cmd.Parameters.AddWithValue("@Name", flower.Name);
    //             cmd.Parameters.AddWithValue("@Color", flower.Color);
    //             cmd.Parameters.AddWithValue("@Price", flower.Price);
    //             cmd.ExecuteNonQuery();
    //         }
    //     }
    // }
    //
    // public void DeleteFlower(Flower flower)
    // {
    //     using (SqlConnection con = GetConnection())
    //     {
    //         con.Open();
    //         using (SqlCommand cmd = con.CreateCommand())
    //         {
    //             cmd.CommandText = "delete from dbo.Flowers where FlowerID = @FlowerID";
    //             cmd.Parameters.AddWithValue("@FlowerID", flower.FlowerId);
    //             cmd.ExecuteNonQuery();
    //         }
    //     }
    // }
}