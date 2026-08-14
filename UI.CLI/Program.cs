using Domain;
using DataAccess.SqlServer;

FlowerDao flowerDao = new FlowerDao();
IList<Flower> flowers = flowerDao.GetFlowers();

foreach (Flower flower in flowers)
{
    Console.WriteLine(flower);
}