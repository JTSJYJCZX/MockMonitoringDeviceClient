using BMHSClient.JTJC;
using BMHSClient.ReceiveMonitoringDataServer.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BHMSClient
{
    //辅助类，增删改查方法
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Thread.Sleep(10000);
                PostData().Wait();
            }
        }

        static async Task PostData()
        {
            const string serviceUri = "http://localhost:53109/odata";
            var container = new DefaultContainer(new Uri(serviceUri));
            var random = new Random();
            await PostCableForceDatas(container, random);
            await PostConcreteStrainDatas(container, random);
            await PostDisplacementDatas(container, random);
            await PostHumidityDatas(container, random);
            await PostSteelArchStrainDatas(container, random);
            await PostSteelLatticeStrainDatas(container, random);
            await PostTemperatureDatas(container, random);
            await PostWindLoadDatas(container, random);
        }

        private static async Task PostConcreteStrainDatas(DefaultContainer container, Random random)
        {
            const int startNumberOfConcreteStrainPoints = 79;
            const int endNumberOfConcreteStrainPoints = 94;
            for (int i = startNumberOfConcreteStrainPoints; i <= endNumberOfConcreteStrainPoints; i++)
            {
                var newConcreteStrainData = new Original_ConcreteStrainTable()
                {
                    PointsNumberId = i,
                    Temperature = random.Next(0, 35),
                    Time = DateTime.Now,
                };
                if ((DateTime.Now.Second > 50) || (DateTime.Now.Second < 30 && DateTime.Now.Second > 20))
                {
                    newConcreteStrainData.Strain = random.Next(-100, 125);
                }
                else
                {
                    newConcreteStrainData.Strain = random.Next(-64, 80);

                }
                await AddOriginal_ConcreteStrainTableEntity(container, newConcreteStrainData);
            }
        }

        static async Task AddOriginal_ConcreteStrainTableEntity(DefaultContainer container, Original_ConcreteStrainTable entity)
        {
            container.AddToOriginal_ConcreteStrains(entity);
            await container.SaveChangesAsync();
        }

        private static async Task PostCableForceDatas(DefaultContainer container, Random random)
        {
            const int startNumberOfCableForcePoints = 121;
            const int endNumberOfCableForcePoints = 158;
            for (int i = startNumberOfCableForcePoints; i <= endNumberOfCableForcePoints; i++)
            {
                var newCableForceData = new Original_CableForceTable()
                {
                    PointsNumberId = i,
                    Temperature = random.Next(0, 35),
                    Time = DateTime.Now,
                };
                if ((DateTime.Now.Second > 50) || (DateTime.Now.Second < 30 && DateTime.Now.Second > 20))
                {
                    newCableForceData.CableForce = random.Next(800, 3200);
                }
                else
                {
                    newCableForceData.CableForce = random.Next(800, 2000);

                }
                await AddOriginal_CableForceTableEntity(container, newCableForceData);
            }
        }

        static async Task AddOriginal_CableForceTableEntity(DefaultContainer container, Original_CableForceTable entity)
        {
            container.AddToOriginal_CableForces(entity);
            await container.SaveChangesAsync();
        }

        private static async Task PostDisplacementDatas(DefaultContainer container, Random random)
        {
            const int startNumberOfDisplacementPoints = 95;
            const int endNumberOfDisplacementPoints = 120;
            for (int i = startNumberOfDisplacementPoints; i <= endNumberOfDisplacementPoints; i++)
            {
                var newDisplacementData = new Original_DisplacementTable()
                {
                    PointsNumberId = i,
                    Time = DateTime.Now,
                };
                if ((DateTime.Now.Second > 50) || (DateTime.Now.Second < 30 && DateTime.Now.Second > 20))
                {
                    newDisplacementData.Displacement = random.Next(-65, 65);
                }
                else
                {
                    newDisplacementData.Displacement = random.Next(-40, 40);

                }
                await AddOriginal_DisplacementTableEntity(container, newDisplacementData);
            }
        }

        static async Task AddOriginal_DisplacementTableEntity(DefaultContainer container, Original_DisplacementTable entity)
        {
            container.AddToOriginal_Displacements(entity);
            await container.SaveChangesAsync();
        }

        static async Task PostHumidityDatas(DefaultContainer container, Random random)
        {
            const int startNumberOfHumidityPoints = 159;
            const int endNumberOfHumidityPoints = 167;
            for (int i = startNumberOfHumidityPoints; i <= endNumberOfHumidityPoints; i++)
            {
                var newHumidityData = new Original_HumidityTable()
                {
                    PointsNumberId = i,
                    Time = DateTime.Now,
                };
                if ((DateTime.Now.Second > 50) || (DateTime.Now.Second < 30 && DateTime.Now.Second > 20))
                {
                    newHumidityData.Humidity = random.Next(30, 100);
                }
                else
                {
                    newHumidityData.Humidity = random.Next(30, 64);

                }
                await AddOriginal_HumidityTableEntity(container, newHumidityData);
            }
        }

        static async Task AddOriginal_HumidityTableEntity(DefaultContainer container, Original_HumidityTable entity)
        {
            container.AddToOriginal_Humiditys(entity);
            await container.SaveChangesAsync();
        }

        static async Task PostSteelArchStrainDatas(DefaultContainer container, Random random)
        {
            const int startNumberOfSteelArchStrainPoints = 1;
            const int endNumberOfSteelArchStrainPoints = 48;
            for (int i = startNumberOfSteelArchStrainPoints; i <= endNumberOfSteelArchStrainPoints; i++)
            {
                var newSteelArchStrainData = new Original_SteelArchStrainTable()
                {
                    PointsNumberId = i,
                    Temperature = random.Next(0, 35),
                    Time = DateTime.Now,
                };
                if ((DateTime.Now.Second > 50) || (DateTime.Now.Second < 30 && DateTime.Now.Second > 20))
                {
                    newSteelArchStrainData.Strain = random.Next(-430, 430);
                }
                else
                {
                    newSteelArchStrainData.Strain = random.Next(-280, 280);

                }
                await AddOriginal_SteelArchStrainTableEntity(container, newSteelArchStrainData);
            }
        }

        static async Task AddOriginal_SteelArchStrainTableEntity(DefaultContainer container, Original_SteelArchStrainTable entity)
        {
            container.AddToOriginal_SteelArchStrains(entity);
            await container.SaveChangesAsync();
        }

        static async Task PostSteelLatticeStrainDatas(DefaultContainer container, Random random)
        {
            const int startNumberOfSteelLatticeStrainPoints = 49;
            const int endNumberOfSteelLatticeStrainPoints = 78;
            for (int i = startNumberOfSteelLatticeStrainPoints; i <= endNumberOfSteelLatticeStrainPoints; i++)
            {
                var newSteelLatticeStrainData = new Original_SteelLatticeStrainTable()
                {
                    PointsNumberId = i,
                    Temperature = random.Next(0, 35),
                    Time = DateTime.Now,
                };
                if ((DateTime.Now.Second > 50) || (DateTime.Now.Second < 30 && DateTime.Now.Second > 20))
                {
                    newSteelLatticeStrainData.Strain = random.Next(-430, 430);
                }
                else
                {
                    newSteelLatticeStrainData.Strain = random.Next(-280, 280);

                }
                await AddOriginal_SteelLatticeStrainTableEntity(container, newSteelLatticeStrainData);
            }
        }

        static async Task AddOriginal_SteelLatticeStrainTableEntity(DefaultContainer container, Original_SteelLatticeStrainTable entity)
        {
            container.AddToOriginal_SteelLatticeStrains(entity);
            await container.SaveChangesAsync();
        }

        static async Task PostTemperatureDatas(DefaultContainer container, Random random)
        {
            const int startNumberOfTemperaturePoints = 168;
            const int endNumberOfTemperaturePoints = 176;
            for (int i = startNumberOfTemperaturePoints; i <= endNumberOfTemperaturePoints; i++)
            {
                var newTemperatureData = new Original_TemperatureTable()
                {
                    PointsNumberId = i,
                    Time = DateTime.Now,
                };
                if ((DateTime.Now.Second > 50) || (DateTime.Now.Second < 30 && DateTime.Now.Second > 20))
                {
                    newTemperatureData.Temperature = random.Next(-24, 100);
                }
                else
                {
                    newTemperatureData.Temperature = random.Next(-16, 64);

                }
                await AddOriginal_TemperatureTableEntity(container, newTemperatureData);
            }
        }

        static async Task AddOriginal_TemperatureTableEntity(DefaultContainer container, Original_TemperatureTable entity)
        {
            container.AddToOriginal_Temperatures(entity);
            await container.SaveChangesAsync();
        }

        static async Task PostWindLoadDatas(DefaultContainer container, Random random)
        {
            const int startNumberOfWindLoadPoints = 177;
            const int endNumberOfWindLoadPoints = 177;
            for (int i = startNumberOfWindLoadPoints; i <= endNumberOfWindLoadPoints; i++)
            {
                var newWindLoadData = new Original_WindLoadTable()
                {
                    PointsNumberId = i,
                    Time = DateTime.Now,
                };
                if ((DateTime.Now.Second > 50) || (DateTime.Now.Second < 30 && DateTime.Now.Second > 20))
                {
                    newWindLoadData.WindSpeed = random.Next(0, 50);
                }
                else
                {
                    newWindLoadData.WindSpeed = random.Next(0, 32);

                }
                await AddOriginal_WindLoadTableEntity(container, newWindLoadData);
            }
        }

        static async Task AddOriginal_WindLoadTableEntity(DefaultContainer container, Original_WindLoadTable entity)
        {
            container.AddToOriginal_WindLoads(entity);
            await container.SaveChangesAsync();
        }


    }
}
