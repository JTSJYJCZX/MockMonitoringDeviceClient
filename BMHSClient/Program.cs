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
                if (newConcreteStrainData.PointsNumberId == 79 || newConcreteStrainData.PointsNumberId == 91 && newConcreteStrainData.Time.Hour == 7 && newConcreteStrainData.Time.Minute == 35)
                {
                    newConcreteStrainData.Strain = -1100;
                }
                //设置混凝土拱肋上缘的应变值
                else if ((newConcreteStrainData.PointsNumberId >= 79 && newConcreteStrainData.PointsNumberId <= 80) || (newConcreteStrainData.PointsNumberId >= 83 && newConcreteStrainData.PointsNumberId <= 84) || (newConcreteStrainData.PointsNumberId >= 87 && newConcreteStrainData.PointsNumberId <= 88) || (newConcreteStrainData.PointsNumberId >= 91 && newConcreteStrainData.PointsNumberId <= 92))
                {
                    if (newConcreteStrainData.Time.Hour >= 0 && newConcreteStrainData.Time.Hour <= 6)
                    {
                        newConcreteStrainData.Strain = random.Next(-150, -100);
                    }
                    else if (newConcreteStrainData.Time.Hour >= 7 && newConcreteStrainData.Time.Hour <= 8)
                    {
                        if (newConcreteStrainData.Time.Minute == 17)
                        {
                            newConcreteStrainData.Strain = random.Next(-230, -50);//可能红色报警
                        }
                        else
                        {
                            newConcreteStrainData.Strain = random.Next(-175, -90);
                        }
                    }
                    else if (newConcreteStrainData.Time.Hour >= 9 && newConcreteStrainData.Time.Hour <= 11)
                    {
                        newConcreteStrainData.Strain = random.Next(-175, -90);
                    }
                    else if (newConcreteStrainData.Time.Hour >= 12 && newConcreteStrainData.Time.Hour <= 14)
                    {
                        if (newConcreteStrainData.Time.Minute == 17)
                        {
                            newConcreteStrainData.Strain = random.Next(-230, -50);//可能红色报警
                        }
                        else
                        {
                            newConcreteStrainData.Strain = random.Next(-175, -90);
                        }
                    }
                    else if (newConcreteStrainData.Time.Hour >= 15 && newConcreteStrainData.Time.Hour <= 16)
                    {
                        newConcreteStrainData.Strain = random.Next(-175, -90);
                    }
                    else if (newConcreteStrainData.Time.Hour >= 17 && newConcreteStrainData.Time.Hour <= 19)
                    {
                        if (newConcreteStrainData.Time.Minute == 17)
                        {
                            newConcreteStrainData.Strain = random.Next(-230, -50);//可能红色报警
                        }
                        else
                        {
                            newConcreteStrainData.Strain = random.Next(-175, -90);
                        }
                    }
                    else
                    {
                        newConcreteStrainData.Strain = random.Next(-150, -100);
                    }
                }
                else
                {
                    if (newConcreteStrainData.Time.Hour >= 0 && newConcreteStrainData.Time.Hour <= 6)
                    {
                        newConcreteStrainData.Strain = random.Next(-160, -100);
                    }
                    else if (newConcreteStrainData.Time.Hour >= 7 && newConcreteStrainData.Time.Hour <= 8)
                    {
                        if (newConcreteStrainData.Time.Minute == 17)
                        {
                            newConcreteStrainData.Strain = random.Next(-260, -170);//可能红色报警
                        }
                        else
                        {
                            newConcreteStrainData.Strain = random.Next(-195, -150);
                        }
                    }
                    else if (newConcreteStrainData.Time.Hour >= 9 && newConcreteStrainData.Time.Hour <= 11)
                    {
                        newConcreteStrainData.Strain = random.Next(-195, -150);
                    }
                    else if (newConcreteStrainData.Time.Hour >= 12 && newConcreteStrainData.Time.Hour <= 14)
                    {
                        if (newConcreteStrainData.Time.Minute == 17)
                        {
                            newConcreteStrainData.Strain = random.Next(-260, -170);//可能红色报警
                        }
                        else
                        {
                            newConcreteStrainData.Strain = random.Next(-195, -150);
                        }
                    }
                    else if (newConcreteStrainData.Time.Hour >= 15 && newConcreteStrainData.Time.Hour <= 16)
                    {
                        newConcreteStrainData.Strain = random.Next(-195, -150);
                    }
                    else if (newConcreteStrainData.Time.Hour >= 17 && newConcreteStrainData.Time.Hour <= 19)
                    {
                        if (newConcreteStrainData.Time.Minute == 17)
                        {
                            newConcreteStrainData.Strain = random.Next(-260, -170);//可能红色报警
                        }
                        else
                        {
                            newConcreteStrainData.Strain = random.Next(-195, -150);
                        }
                    }
                    else
                    {
                        newConcreteStrainData.Strain = random.Next(-160, -100);
                    }
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
                if (newCableForceData.PointsNumberId == 128 && newCableForceData.PointsNumberId == 131 && newCableForceData.Time.Hour == 7 && newCableForceData.Time.Minute == 35)
                {
                    newCableForceData.CableForce = 11000;
                }
                //设置上层吊杆
                else if (newCableForceData.PointsNumberId >= 121 && newCableForceData.PointsNumberId <= 138)
                {
                    if (newCableForceData.Time.Hour >= 0 && newCableForceData.Time.Hour <= 6)
                    {
                        newCableForceData.CableForce = random.Next(460, 800);
                    }
                    else if (newCableForceData.Time.Hour >= 7 && newCableForceData.Time.Hour <= 8)
                    {
                        if (newCableForceData.Time.Minute == 17)
                        {
                            newCableForceData.CableForce = random.Next(1700, 2200);//可能红色报警
                        }
                        newCableForceData.CableForce = random.Next(700, 1400);
                    }
                    else if (newCableForceData.Time.Hour >= 9 && newCableForceData.Time.Hour <= 11)
                    {
                        newCableForceData.CableForce = random.Next(500, 1200);
                    }
                    else if (newCableForceData.Time.Hour >= 12 && newCableForceData.Time.Hour <= 14)
                    {
                        if (newCableForceData.Time.Minute == 17)
                        {
                            newCableForceData.CableForce = random.Next(1700, 2200);//可能红色报警
                        }
                        newCableForceData.CableForce = random.Next(700, 1400);
                    }
                    else if (newCableForceData.Time.Hour >= 15 && newCableForceData.Time.Hour <= 16)
                    {
                        newCableForceData.CableForce = random.Next(500, 1200);
                    }
                    else if (newCableForceData.Time.Hour >= 17 && newCableForceData.Time.Hour <= 19)
                    {
                        if (newCableForceData.Time.Minute == 17)
                        {
                            newCableForceData.CableForce = random.Next(1700, 2200);//可能红色报警
                        }
                        newCableForceData.CableForce = random.Next(700, 1400);
                    }
                    else
                    {
                        newCableForceData.CableForce = random.Next(500, 1200);
                    }
                }
                //设置下层吊杆
                else if (newCableForceData.PointsNumberId >= 139 && newCableForceData.PointsNumberId <= 146)
                {
                    if (newCableForceData.Time.Hour >= 0 && newCableForceData.Time.Hour <= 6)
                    {
                        newCableForceData.CableForce = random.Next(460, 1800);
                    }
                    else if (newCableForceData.Time.Hour >= 7 && newCableForceData.Time.Hour <= 8)
                    {
                        if (newCableForceData.Time.Minute == 17)
                        {
                            newCableForceData.CableForce = random.Next(2400, 3100);//可能红色报警
                        }
                        newCableForceData.CableForce = random.Next(1500, 2200);
                    }
                    else if (newCableForceData.Time.Hour >= 9 && newCableForceData.Time.Hour <= 11)
                    {
                        newCableForceData.CableForce = random.Next(1000, 1200);
                    }
                    else if (newCableForceData.Time.Hour >= 12 && newCableForceData.Time.Hour <= 14)
                    {
                        if (newCableForceData.Time.Minute == 17)
                        {
                            newCableForceData.CableForce = random.Next(2400, 3100);//可能红色报警
                        }
                        newCableForceData.CableForce = random.Next(1500, 2200);
                    }
                    else if (newCableForceData.Time.Hour >= 15 && newCableForceData.Time.Hour <= 16)
                    {
                        newCableForceData.CableForce = random.Next(1000, 2000);
                    }
                    else if (newCableForceData.Time.Hour >= 17 && newCableForceData.Time.Hour <= 19)
                    {
                        if (newCableForceData.Time.Minute == 17)
                        {
                            newCableForceData.CableForce = random.Next(2400, 3100);//可能红色报警
                        }
                        newCableForceData.CableForce = random.Next(1500, 2200);
                    }
                    else
                    {
                        newCableForceData.CableForce = random.Next(1000, 2000);
                    }
                }
                //设置柔性系杆
                else if (newCableForceData.PointsNumberId >= 147 && newCableForceData.PointsNumberId <= 158)
                {
                    if (newCableForceData.Time.Hour >= 0 && newCableForceData.Time.Hour <= 6)
                    {
                        newCableForceData.CableForce = random.Next(800, 1200);
                    }
                    else if (newCableForceData.Time.Hour >= 7 && newCableForceData.Time.Hour <= 8)
                    {
                        if (newCableForceData.Time.Minute == 17)
                        {
                            newCableForceData.CableForce = random.Next(1400, 2400);//可能红色报警
                        }
                        newCableForceData.CableForce = random.Next(1000, 1600);
                    }
                    else if (newCableForceData.Time.Hour >= 9 && newCableForceData.Time.Hour <= 11)
                    {
                        newCableForceData.CableForce = random.Next(1000, 1600);
                    }
                    else if (newCableForceData.Time.Hour >= 12 && newCableForceData.Time.Hour <= 14)
                    {
                        if (newCableForceData.Time.Minute == 17)
                        {
                            newCableForceData.CableForce = random.Next(1400, 2400);//可能红色报警
                        }
                        newCableForceData.CableForce = random.Next(1000, 1600);
                    }
                    else if (newCableForceData.Time.Hour >= 15 && newCableForceData.Time.Hour <= 16)
                    {
                        newCableForceData.CableForce = random.Next(1000, 1600);
                    }
                    else if (newCableForceData.Time.Hour >= 17 && newCableForceData.Time.Hour <= 19)
                    {
                        if (newCableForceData.Time.Minute == 17)
                        {
                            newCableForceData.CableForce = random.Next(1400, 2400);//可能红色报警
                        }
                        newCableForceData.CableForce = random.Next(1000, 1600);
                    }
                    else
                    {
                        newCableForceData.CableForce = random.Next(800, 1400);
                    }
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
                //异常设置
                if (newDisplacementData.PointsNumberId == 98 || newDisplacementData.PointsNumberId == 110 || newDisplacementData.PointsNumberId == 114 && newDisplacementData.Time.Hour == 7 && newDisplacementData.Time.Minute == 35)
                {
                    newDisplacementData.Displacement = 500;
                }
                //拱肋横向和纵向位移设置
                else if (newDisplacementData.PointsNumberId >= 95 && newDisplacementData.PointsNumberId <= 102)
                {
                    if (newDisplacementData.Time.Hour >= 0 && newDisplacementData.Time.Hour <= 6)
                    {
                        newDisplacementData.Displacement = random.Next(-7, 7);
                    }
                    else if (newDisplacementData.Time.Hour >= 7 && newDisplacementData.Time.Hour <= 8)
                    {
                        if (newDisplacementData.Time.Minute == 17)
                        {
                            newDisplacementData.Displacement = random.Next(-17, -10);//可能红色报警
                        }
                        else
                        {
                            newDisplacementData.Displacement = random.Next(-11, 11);
                        }
                    }
                    else if (newDisplacementData.Time.Hour >= 9 && newDisplacementData.Time.Hour <= 11)
                    {
                        newDisplacementData.Displacement = random.Next(-11, 11);
                    }
                    else if (newDisplacementData.Time.Hour >= 12 && newDisplacementData.Time.Hour <= 14)
                    {
                        if (newDisplacementData.Time.Minute == 17)
                        {
                            newDisplacementData.Displacement = random.Next(-17, -10);//可能红色报警
                        }
                        else
                        {
                            newDisplacementData.Displacement = random.Next(-11, 11);
                        }
                    }
                    else if (newDisplacementData.Time.Hour >= 15 && newDisplacementData.Time.Hour <= 16)
                    {
                        newDisplacementData.Displacement = random.Next(-11, 11);
                    }
                    else if (newDisplacementData.Time.Hour >= 17 && newDisplacementData.Time.Hour <= 19)
                    {
                        if (newDisplacementData.Time.Minute == 17)
                        {
                            newDisplacementData.Displacement = random.Next(-17, -10);//可能红色报警
                        }
                        else
                        {
                            newDisplacementData.Displacement = random.Next(-11, 11);
                        }
                    }
                    else
                    {
                        newDisplacementData.Displacement = random.Next(-10, 10);
                    }
                }
                //拱肋边拱竖向挠度
                else if (newDisplacementData.PointsNumberId == 103 || newDisplacementData.PointsNumberId == 105)
                {
                    if (newDisplacementData.Time.Hour >= 0 && newDisplacementData.Time.Hour <= 6)
                    {
                        newDisplacementData.Displacement = random.Next(-12, 4);
                    }
                    else if (newDisplacementData.Time.Hour >= 7 && newDisplacementData.Time.Hour <= 8)
                    {
                        if (newDisplacementData.Time.Minute == 17)
                        {
                            newDisplacementData.Displacement = random.Next(-28, -16);//可能红色报警
                        }
                        else
                        {
                            newDisplacementData.Displacement = random.Next(-12, 5);
                        }
                    }
                    else if (newDisplacementData.Time.Hour >= 9 && newDisplacementData.Time.Hour <= 11)
                    {
                        newDisplacementData.Displacement = random.Next(-15, 5);
                    }
                    else if (newDisplacementData.Time.Hour >= 12 && newDisplacementData.Time.Hour <= 14)
                    {
                        if (newDisplacementData.Time.Minute == 17)
                        {
                            newDisplacementData.Displacement = random.Next(-28, -16);//可能红色报警
                        }
                        else
                        {
                            newDisplacementData.Displacement = random.Next(-15, 5);
                        }
                    }
                    else if (newDisplacementData.Time.Hour >= 15 && newDisplacementData.Time.Hour <= 16)
                    {
                        newDisplacementData.Displacement = random.Next(-15, 5);
                    }
                    else if (newDisplacementData.Time.Hour >= 17 && newDisplacementData.Time.Hour <= 19)
                    {
                        if (newDisplacementData.Time.Minute == 17)
                        {
                            newDisplacementData.Displacement = random.Next(-28, -16);//可能红色报警
                        }
                        else
                        {
                            newDisplacementData.Displacement = random.Next(-15, 5);
                        }
                    }
                    else
                    {
                        newDisplacementData.Displacement = random.Next(-12, 4);
                    }
                }
                //拱肋中拱竖向挠度
               else if (newDisplacementData.PointsNumberId == 104 || newDisplacementData.PointsNumberId == 106)
                {
                    if (newDisplacementData.Time.Hour >= 0 && newDisplacementData.Time.Hour <= 6)
                    {
                        newDisplacementData.Displacement = random.Next(-40, 30);
                    }
                    else if (newDisplacementData.Time.Hour >= 7 && newDisplacementData.Time.Hour <= 8)
                    {
                        if (newDisplacementData.Time.Minute == 17)
                        {
                            newDisplacementData.Displacement = random.Next(-100, -60);//可能红色报警
                        }
                        else
                        {
                            newDisplacementData.Displacement = random.Next(-60, 40);
                        }
                    }
                    else if (newDisplacementData.Time.Hour >= 9 && newDisplacementData.Time.Hour <= 11)
                    {
                        newDisplacementData.Displacement = random.Next(-60, 40);
                    }
                    else if (newDisplacementData.Time.Hour >= 12 && newDisplacementData.Time.Hour <= 14)
                    {
                        if (newDisplacementData.Time.Minute == 17)
                        {
                            newDisplacementData.Displacement = random.Next(-100, -60);//可能红色报警
                        }
                        else
                        {
                            newDisplacementData.Displacement = random.Next(-60, 40);
                        }
                    }
                    else if (newDisplacementData.Time.Hour >= 15 && newDisplacementData.Time.Hour <= 16)
                    {
                        newDisplacementData.Displacement = random.Next(-60, 40);
                    }
                    else if (newDisplacementData.Time.Hour >= 17 && newDisplacementData.Time.Hour <= 19)
                    {
                        if (newDisplacementData.Time.Minute == 17)
                        {
                            newDisplacementData.Displacement = random.Next(-100, -60);//可能红色报警
                        }
                        else
                        {
                            newDisplacementData.Displacement = random.Next(-60, 40);
                        }
                    }
                    else
                    {
                        newDisplacementData.Displacement = random.Next(-40, 30);
                    }
                }
                //边跨主梁竖向挠度
               else if (newDisplacementData.PointsNumberId == 107 || newDisplacementData.PointsNumberId == 109 || newDisplacementData.PointsNumberId == 110 || newDisplacementData.PointsNumberId == 112)
                {
                    if (newDisplacementData.Time.Hour >= 0 && newDisplacementData.Time.Hour <= 6)
                    {
                        newDisplacementData.Displacement = random.Next(-25, 3);
                    }
                    else if (newDisplacementData.Time.Hour >= 7 && newDisplacementData.Time.Hour <= 8)
                    {
                        if (newDisplacementData.Time.Minute == 17)
                        {
                            newDisplacementData.Displacement = random.Next(-55, -31);//可能红色报警
                        }
                        else
                        {
                            newDisplacementData.Displacement = random.Next(-35, 4);
                        }
                    }
                    else if (newDisplacementData.Time.Hour >= 9 && newDisplacementData.Time.Hour <= 11)
                    {
                        newDisplacementData.Displacement = random.Next(-35, 4);
                    }
                    else if (newDisplacementData.Time.Hour >= 12 && newDisplacementData.Time.Hour <= 14)
                    {
                        if (newDisplacementData.Time.Minute == 17)
                        {
                            newDisplacementData.Displacement = random.Next(-55, -31);//可能红色报警
                        }
                        else
                        {
                            newDisplacementData.Displacement = random.Next(-35, 4);
                        }
                    }
                    else if (newDisplacementData.Time.Hour >= 15 && newDisplacementData.Time.Hour <= 16)
                    {
                        newDisplacementData.Displacement = random.Next(-35, 4);
                    }
                    else if (newDisplacementData.Time.Hour >= 17 && newDisplacementData.Time.Hour <= 19)
                    {
                        if (newDisplacementData.Time.Minute == 17)
                        {
                            newDisplacementData.Displacement = random.Next(-55, -31);//可能红色报警
                        }
                        else
                        {
                            newDisplacementData.Displacement = random.Next(-35, 4);
                        }
                    }
                    else
                    {
                        newDisplacementData.Displacement = random.Next(-25, 3);
                    }
                }
                //中跨主梁竖向挠度
               else if (newDisplacementData.PointsNumberId == 108 || newDisplacementData.PointsNumberId == 111)
                {
                    if (newDisplacementData.Time.Hour >= 0 && newDisplacementData.Time.Hour <= 6)
                    {
                        newDisplacementData.Displacement = random.Next(-60, 30);
                    }
                    else if (newDisplacementData.Time.Hour >= 7 && newDisplacementData.Time.Hour <= 8)
                    {
                        if (newDisplacementData.Time.Minute == 17)
                        {
                            newDisplacementData.Displacement = random.Next(-125, -80);//可能红色报警
                        }
                        else
                        {
                            newDisplacementData.Displacement = random.Next(-80, 50);
                        }
                    }
                    else if (newDisplacementData.Time.Hour >= 9 && newDisplacementData.Time.Hour <= 11)
                    {
                        newDisplacementData.Displacement = random.Next(-80, 50);
                    }
                    else if (newDisplacementData.Time.Hour >= 12 && newDisplacementData.Time.Hour <= 14)
                    {
                        if (newDisplacementData.Time.Minute == 17)
                        {
                            newDisplacementData.Displacement = random.Next(-125, -80);//可能红色报警
                        }
                        else
                        {
                            newDisplacementData.Displacement = random.Next(-80, 50);
                        }
                    }
                    else if (newDisplacementData.Time.Hour >= 15 && newDisplacementData.Time.Hour <= 16)
                    {
                        newDisplacementData.Displacement = random.Next(-80, 50);
                    }
                    else if (newDisplacementData.Time.Hour >= 17 && newDisplacementData.Time.Hour <= 19)
                    {
                        if (newDisplacementData.Time.Minute == 17)
                        {
                            newDisplacementData.Displacement = random.Next(-125, -80);//可能红色报警
                        }
                        else
                        {
                            newDisplacementData.Displacement = random.Next(-80, 50);
                        }
                    }
                    else
                    {
                        newDisplacementData.Displacement = random.Next(-60, 30);
                    }
                }
                //过渡墩纵向位移
              else if (newDisplacementData.PointsNumberId >= 117 && newDisplacementData.PointsNumberId <= 120)
                {
                    if (newDisplacementData.Time.Hour >= 0 && newDisplacementData.Time.Hour <= 6)
                    {
                        newDisplacementData.Displacement = random.Next(20, 60);
                    }
                    else if (newDisplacementData.Time.Hour >= 7 && newDisplacementData.Time.Hour <= 8)
                    {
                        if (newDisplacementData.Time.Minute == 17)
                        {
                            newDisplacementData.Displacement = random.Next(70, 110);//可能红色报警
                        }
                        else
                        {
                            newDisplacementData.Displacement = random.Next(40, 79);
                        }
                    }
                    else if (newDisplacementData.Time.Hour >= 9 && newDisplacementData.Time.Hour <= 11)
                    {
                        newDisplacementData.Displacement = random.Next(40, 79);
                    }
                    else if (newDisplacementData.Time.Hour >= 12 && newDisplacementData.Time.Hour <= 14)
                    {
                        if (newDisplacementData.Time.Minute == 17)
                        {
                            newDisplacementData.Displacement = random.Next(70, 110);//可能红色报警
                        }
                        else
                        {
                            newDisplacementData.Displacement = random.Next(40, 79);
                        }
                    }
                    else if (newDisplacementData.Time.Hour >= 15 && newDisplacementData.Time.Hour <= 16)
                    {
                        newDisplacementData.Displacement = random.Next(40, 79);
                    }
                    else if (newDisplacementData.Time.Hour >= 17 && newDisplacementData.Time.Hour <= 19)
                    {
                        if (newDisplacementData.Time.Minute == 17)
                        {
                            newDisplacementData.Displacement = random.Next(70, 110);//可能红色报警
                        }
                        else
                        {
                            newDisplacementData.Displacement = random.Next(40, 79);
                        }
                    }
                    else
                    {
                        newDisplacementData.Displacement = random.Next(20, 60);
                    }
                }
                //伸缩缝纵向位移
               else
                {
                    if (newDisplacementData.Time.Hour >= 0 && newDisplacementData.Time.Hour <= 6)
                    {
                        newDisplacementData.Displacement = random.Next(20, 80);
                    }
                    else if (newDisplacementData.Time.Hour >= 7 && newDisplacementData.Time.Hour <= 8)
                    {
                        if (newDisplacementData.Time.Minute == 17)
                        {
                            newDisplacementData.Displacement = random.Next(100, 160);//可能红色报警
                        }
                        else
                        {
                            newDisplacementData.Displacement = random.Next(40, 110);
                        }
                    }
                    else if (newDisplacementData.Time.Hour >= 9 && newDisplacementData.Time.Hour <= 11)
                    {
                        newDisplacementData.Displacement = random.Next(40, 110);
                    }
                    else if (newDisplacementData.Time.Hour >= 12 && newDisplacementData.Time.Hour <= 14)
                    {
                        if (newDisplacementData.Time.Minute == 17)
                        {
                            newDisplacementData.Displacement = random.Next(100, 160);//可能红色报警
                        }
                        else
                        {
                            newDisplacementData.Displacement = random.Next(40, 110);
                        }
                    }
                    else if (newDisplacementData.Time.Hour >= 15 && newDisplacementData.Time.Hour <= 16)
                    {
                        newDisplacementData.Displacement = random.Next(40, 110);
                    }
                    else if (newDisplacementData.Time.Hour >= 17 && newDisplacementData.Time.Hour <= 19)
                    {
                        if (newDisplacementData.Time.Minute == 17)
                        {
                            newDisplacementData.Displacement = random.Next(100, 160);//可能红色报警
                        }
                        else
                        {
                            newDisplacementData.Displacement = random.Next(40, 110);
                        }
                    }
                    else
                    {
                        newDisplacementData.Displacement = random.Next(20, 80);
                    }
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
            double timeForCalculate;
            for (int i = startNumberOfHumidityPoints; i <= endNumberOfHumidityPoints; i++)
            {
                var newHumidityData = new Original_HumidityTable()
                {
                    PointsNumberId = i,
                    Time = DateTime.Now,
                };
                timeForCalculate = Convert.ToDouble(newHumidityData.Time.Hour) + Convert.ToDouble(newHumidityData.Time.Minute) / 60;

                if (newHumidityData.PointsNumberId == 159)
                {
                    newHumidityData.Humidity = Math.Round((-0.0000078423 * Math.Pow(timeForCalculate, 6) + 0.0002969528 * Math.Pow(timeForCalculate, 5) - 0.0003479320 * Math.Pow(timeForCalculate, 4) - 0.0882313919 * Math.Pow(timeForCalculate, 3) + 0.9074929115 * Math.Pow(timeForCalculate, 2) - 2.7612024709 * timeForCalculate + 94.4810448062 + random.Next(-5, 5)),2);
                }
                else
                {
                    newHumidityData.Humidity = Math.Round((0.0000003604 * Math.Pow(timeForCalculate, 6) - 0.0000414864 * Math.Pow(timeForCalculate, 5) + 0.0021461937 * Math.Pow(timeForCalculate, 4) - 0.0521791190 * Math.Pow(timeForCalculate, 3) + 0.5739883341 * Math.Pow(timeForCalculate, 2) - 2.1637451666 * timeForCalculate + 42.5826680075 + random.Next(-5, 5)),2);

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
                    Temperature = random.Next(30, 35),
                    Time = DateTime.Now,
                };
                if (newSteelArchStrainData.PointsNumberId == 7 || newSteelArchStrainData.PointsNumberId == 21 && newSteelArchStrainData.Time.Hour == 7 && newSteelArchStrainData.Time.Minute == 35)
                {
                    newSteelArchStrainData.Strain = 1100;
                }
                //设置钢拱肋A、C、E截面的应变值
                else if ((newSteelArchStrainData.PointsNumberId >= 1 && newSteelArchStrainData.PointsNumberId <= 8) || (newSteelArchStrainData.PointsNumberId >= 17 && newSteelArchStrainData.PointsNumberId <= 24) || (newSteelArchStrainData.PointsNumberId >= 33 && newSteelArchStrainData.PointsNumberId <= 40))
                {
                    if (newSteelArchStrainData.Time.Hour >= 0 && newSteelArchStrainData.Time.Hour <= 6)
                    {
                        newSteelArchStrainData.Strain = random.Next(-260, -50);
                    }
                    else if (newSteelArchStrainData.Time.Hour >= 7 && newSteelArchStrainData.Time.Hour <= 8)
                    {
                        if (newSteelArchStrainData.Time.Minute == 17)
                        {
                            newSteelArchStrainData.Strain = random.Next(-600, -400);//可能红色报警
                        }
                        else
                        {
                            newSteelArchStrainData.Strain = random.Next(-450, -260);
                        }
                    }
                    else if (newSteelArchStrainData.Time.Hour >= 9 && newSteelArchStrainData.Time.Hour <= 11)
                    {
                        newSteelArchStrainData.Strain = random.Next(-400, -260);
                    }
                    else if (newSteelArchStrainData.Time.Hour >= 12 && newSteelArchStrainData.Time.Hour <= 14)
                    {
                        if (newSteelArchStrainData.Time.Minute == 17)
                        {
                            newSteelArchStrainData.Strain = random.Next(-600, -400);//可能红色报警
                        }
                        else
                        {
                            newSteelArchStrainData.Strain = random.Next(-450, -260);
                        }
                    }
                    else if (newSteelArchStrainData.Time.Hour >= 15 && newSteelArchStrainData.Time.Hour <= 16)
                    {
                        newSteelArchStrainData.Strain = random.Next(-400, -260);
                    }
                    else if (newSteelArchStrainData.Time.Hour >= 17 && newSteelArchStrainData.Time.Hour <= 19)
                    {
                        if (newSteelArchStrainData.Time.Minute == 17)
                        {
                            newSteelArchStrainData.Strain = random.Next(-600, 400);//可能红色报警
                        }
                        else
                        {
                            newSteelArchStrainData.Strain = random.Next(-450, -260);
                        }
                    }
                    else
                    {
                        newSteelArchStrainData.Strain = random.Next(-350, -150);
                    }
                }
                //设置钢拱肋B、D截面的应变值
              else if ((newSteelArchStrainData.PointsNumberId >= 9 && newSteelArchStrainData.PointsNumberId <= 16) || (newSteelArchStrainData.PointsNumberId >= 25 && newSteelArchStrainData.PointsNumberId <= 32))
                {
                    if (newSteelArchStrainData.Time.Hour >= 0 && newSteelArchStrainData.Time.Hour <= 6)
                    {
                        newSteelArchStrainData.Strain = random.Next(-260, -50);
                    }
                    else if (newSteelArchStrainData.Time.Hour >= 7 && newSteelArchStrainData.Time.Hour <= 8)
                    {
                        if (newSteelArchStrainData.Time.Minute == 17)
                        {
                            newSteelArchStrainData.Strain = random.Next(-810, -580);//可能红色报警
                        }
                        else
                        {
                            newSteelArchStrainData.Strain = random.Next(-580, -260);
                        }
                    }
                    else if (newSteelArchStrainData.Time.Hour >= 9 && newSteelArchStrainData.Time.Hour <= 11)
                    {
                        newSteelArchStrainData.Strain = random.Next(-580, -260);
                    }
                    else if (newSteelArchStrainData.Time.Hour >= 12 && newSteelArchStrainData.Time.Hour <= 14)
                    {
                        if (newSteelArchStrainData.Time.Minute == 17)
                        {
                            newSteelArchStrainData.Strain = random.Next(-810, -580);//可能红色报警
                        }
                        else
                        {
                            newSteelArchStrainData.Strain = random.Next(-580, -260);
                        }
                    }
                    else if (newSteelArchStrainData.Time.Hour >= 15 && newSteelArchStrainData.Time.Hour <= 16)
                    {
                        newSteelArchStrainData.Strain = random.Next(-580, -260);
                    }
                    else if (newSteelArchStrainData.Time.Hour >= 17 && newSteelArchStrainData.Time.Hour <= 19)
                    {
                        if (newSteelArchStrainData.Time.Minute == 17)
                        {
                            newSteelArchStrainData.Strain = random.Next(-810, -580);//可能红色报警
                        }
                        else
                        {
                            newSteelArchStrainData.Strain = random.Next(-580, -260);
                        }
                    }
                    else
                    {
                        newSteelArchStrainData.Strain = random.Next(-350, -150);
                    }
                }
                //设置拱肋横撑A、B截面的应变值
               else if (newSteelArchStrainData.PointsNumberId >= 41 && newSteelArchStrainData.PointsNumberId <= 48)
                {
                    if (newSteelArchStrainData.Time.Hour >= 0 && newSteelArchStrainData.Time.Hour <= 6)
                    {
                        newSteelArchStrainData.Strain = random.Next(-260, 200);
                    }
                    else if (newSteelArchStrainData.Time.Hour >= 7 && newSteelArchStrainData.Time.Hour <= 8)
                    {
                        if (newSteelArchStrainData.Time.Minute == 17)
                        {
                            newSteelArchStrainData.Strain = random.Next(-510, 390);//可能红色报警
                        }
                        else
                        {
                            newSteelArchStrainData.Strain = random.Next(-400, 280);
                        }
                    }
                    else if (newSteelArchStrainData.Time.Hour >= 9 && newSteelArchStrainData.Time.Hour <= 11)
                    {
                        newSteelArchStrainData.Strain = random.Next(-400, 280);
                    }
                    else if (newSteelArchStrainData.Time.Hour >= 12 && newSteelArchStrainData.Time.Hour <= 14)
                    {
                        if (newSteelArchStrainData.Time.Minute == 17)
                        {
                            newSteelArchStrainData.Strain = random.Next(-510, 390);//可能红色报警
                        }
                        else
                        {
                            newSteelArchStrainData.Strain = random.Next(-400, 280);
                        }
                    }
                    else if (newSteelArchStrainData.Time.Hour >= 15 && newSteelArchStrainData.Time.Hour <= 16)
                    {
                        newSteelArchStrainData.Strain = random.Next(-400, 280);
                    }
                    else if (newSteelArchStrainData.Time.Hour >= 17 && newSteelArchStrainData.Time.Hour <= 19)
                    {
                        if (newSteelArchStrainData.Time.Minute == 17)
                        {
                            newSteelArchStrainData.Strain = random.Next(-510, 390);//可能红色报警
                        }
                        else
                        {
                            newSteelArchStrainData.Strain = random.Next(-400, 280);
                        }
                    }
                    else
                    {
                        newSteelArchStrainData.Strain = random.Next(-350, 250);
                    }
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
                    Temperature = random.Next(30, 35),
                    Time = DateTime.Now,
                };
                if (newSteelLatticeStrainData.PointsNumberId == 57 || newSteelLatticeStrainData.PointsNumberId == 61 && newSteelLatticeStrainData.Time.Hour == 7 && newSteelLatticeStrainData.Time.Minute == 35)
                {
                    newSteelLatticeStrainData.Strain = 1100;
                }
                //设置肋间横梁A/B截面/上层钢横梁A/B截面的应变值
               else if (newSteelLatticeStrainData.PointsNumberId >= 49 && newSteelLatticeStrainData.PointsNumberId <= 56)
                {
                    if (newSteelLatticeStrainData.Time.Hour >= 0 && newSteelLatticeStrainData.Time.Hour <= 6)
                    {
                        newSteelLatticeStrainData.Strain = random.Next(-260, 260);
                    }
                    else if (newSteelLatticeStrainData.Time.Hour >= 7 && newSteelLatticeStrainData.Time.Hour <= 8)
                    {
                        if (newSteelLatticeStrainData.Time.Minute == 17)
                        {
                            newSteelLatticeStrainData.Strain = random.Next(-800, 800);//可能红色报警
                        }
                        else
                        {
                            newSteelLatticeStrainData.Strain = random.Next(-450, 260);
                        }
                    }
                    else if (newSteelLatticeStrainData.Time.Hour >= 9 && newSteelLatticeStrainData.Time.Hour <= 11)
                    {
                        newSteelLatticeStrainData.Strain = random.Next(-400, 260);
                    }
                    else if (newSteelLatticeStrainData.Time.Hour >= 12 && newSteelLatticeStrainData.Time.Hour <= 14)
                    {
                        if (newSteelLatticeStrainData.Time.Minute == 17)
                        {
                            newSteelLatticeStrainData.Strain = random.Next(-800, 800);//可能红色报警
                        }
                        else
                        {
                            newSteelLatticeStrainData.Strain = random.Next(-450, 260);
                        }
                    }
                    else if (newSteelLatticeStrainData.Time.Hour >= 15 && newSteelLatticeStrainData.Time.Hour <= 16)
                    {
                        newSteelLatticeStrainData.Strain = random.Next(-400, 260);
                    }
                    else if (newSteelLatticeStrainData.Time.Hour >= 17 && newSteelLatticeStrainData.Time.Hour <= 19)
                    {
                        if (newSteelLatticeStrainData.Time.Minute == 17)
                        {
                            newSteelLatticeStrainData.Strain = random.Next(-800, 800);//可能红色报警
                        }
                        else
                        {
                            newSteelLatticeStrainData.Strain = random.Next(-450, 260);
                        }
                    }
                    else
                    {
                        newSteelLatticeStrainData.Strain = random.Next(-350, 150);
                    }
                }
                //设置钢纵梁A/B截面应变
              else if (newSteelLatticeStrainData.PointsNumberId >= 57 && newSteelLatticeStrainData.PointsNumberId <= 62)
                {
                    if (newSteelLatticeStrainData.Time.Hour >= 0 && newSteelLatticeStrainData.Time.Hour <= 6)
                    {
                        newSteelLatticeStrainData.Strain = random.Next(-260, 50);
                    }
                    else if (newSteelLatticeStrainData.Time.Hour >= 7 && newSteelLatticeStrainData.Time.Hour <= 8)
                    {
                        if (newSteelLatticeStrainData.Time.Minute == 17)
                        {
                            newSteelLatticeStrainData.Strain = random.Next(-810, 500);//可能红色报警
                        }
                        else
                        {
                            newSteelLatticeStrainData.Strain = random.Next(-450, 260);
                        }
                    }
                    else if (newSteelLatticeStrainData.Time.Hour >= 9 && newSteelLatticeStrainData.Time.Hour <= 11)
                    {
                        newSteelLatticeStrainData.Strain = random.Next(-400, 260);
                    }
                    else if (newSteelLatticeStrainData.Time.Hour >= 12 && newSteelLatticeStrainData.Time.Hour <= 14)
                    {
                        if (newSteelLatticeStrainData.Time.Minute == 17)
                        {
                            newSteelLatticeStrainData.Strain = random.Next(-810, 500);//可能红色报警
                        }
                        else
                        {
                            newSteelLatticeStrainData.Strain = random.Next(-450, 260);
                        }
                    }
                    else if (newSteelLatticeStrainData.Time.Hour >= 15 && newSteelLatticeStrainData.Time.Hour <= 16)
                    {
                        newSteelLatticeStrainData.Strain = random.Next(-400, 260);
                    }
                    else if (newSteelLatticeStrainData.Time.Hour >= 17 && newSteelLatticeStrainData.Time.Hour <= 19)
                    {
                        if (newSteelLatticeStrainData.Time.Minute == 17)
                        {
                            newSteelLatticeStrainData.Strain = random.Next(-810, 500);//可能红色报警
                        }
                        else
                        {
                            newSteelLatticeStrainData.Strain = random.Next(-450, 260);
                        }
                    }
                    else
                    {
                        newSteelLatticeStrainData.Strain = random.Next(-350, 150);
                    }
                }
                //设置上层钢性系杆截面的上缘应变值
               else  if ((newSteelLatticeStrainData.PointsNumberId >= 63 && newSteelLatticeStrainData.PointsNumberId <= 64) || (newSteelLatticeStrainData.PointsNumberId >= 67 && newSteelLatticeStrainData.PointsNumberId <= 68) || (newSteelLatticeStrainData.PointsNumberId >= 71 && newSteelLatticeStrainData.PointsNumberId <= 72) || (newSteelLatticeStrainData.PointsNumberId >= 75 && newSteelLatticeStrainData.PointsNumberId <= 76))
                {
                    if (newSteelLatticeStrainData.Time.Hour >= 0 && newSteelLatticeStrainData.Time.Hour <= 6)
                    {
                        newSteelLatticeStrainData.Strain = random.Next(-160, 200);
                    }
                    else if (newSteelLatticeStrainData.Time.Hour >= 7 && newSteelLatticeStrainData.Time.Hour <= 8)
                    {
                        if (newSteelLatticeStrainData.Time.Minute == 17)
                        {
                            newSteelLatticeStrainData.Strain = random.Next(-310, 650);//可能红色报警
                        }
                        else
                        {
                            newSteelLatticeStrainData.Strain = random.Next(-200, 480);
                        }
                    }
                    else if (newSteelLatticeStrainData.Time.Hour >= 9 && newSteelLatticeStrainData.Time.Hour <= 11)
                    {
                        newSteelLatticeStrainData.Strain = random.Next(-200, 480);
                    }
                    else if (newSteelLatticeStrainData.Time.Hour >= 12 && newSteelLatticeStrainData.Time.Hour <= 14)
                    {
                        if (newSteelLatticeStrainData.Time.Minute == 17)
                        {
                            newSteelLatticeStrainData.Strain = random.Next(-310, 650);//可能红色报警
                        }
                        else
                        {
                            newSteelLatticeStrainData.Strain = random.Next(-200, 480);
                        }
                    }
                    else if (newSteelLatticeStrainData.Time.Hour >= 15 && newSteelLatticeStrainData.Time.Hour <= 16)
                    {
                        newSteelLatticeStrainData.Strain = random.Next(-200, 480);
                    }
                    else if (newSteelLatticeStrainData.Time.Hour >= 17 && newSteelLatticeStrainData.Time.Hour <= 19)
                    {
                        if (newSteelLatticeStrainData.Time.Minute == 17)
                        {
                            newSteelLatticeStrainData.Strain = random.Next(-310, 650);//可能红色报警
                        }
                        else
                        {
                            newSteelLatticeStrainData.Strain = random.Next(-200, 480);
                        }
                    }
                    else
                    {
                        newSteelLatticeStrainData.Strain = random.Next(-150, 350);
                    }
                }
              else
                {
                    if (newSteelLatticeStrainData.Time.Hour >= 0 && newSteelLatticeStrainData.Time.Hour <= 6)
                    {
                        newSteelLatticeStrainData.Strain = random.Next(-320, 100);
                    }
                    else if (newSteelLatticeStrainData.Time.Hour >= 7 && newSteelLatticeStrainData.Time.Hour <= 8)
                    {
                        if (newSteelLatticeStrainData.Time.Minute == 17)
                        {
                            newSteelLatticeStrainData.Strain = random.Next(-520, 350);//可能红色报警
                        }
                        else
                        {
                            newSteelLatticeStrainData.Strain = random.Next(-350, 200);
                        }
                    }
                    else if (newSteelLatticeStrainData.Time.Hour >= 9 && newSteelLatticeStrainData.Time.Hour <= 11)
                    {
                        newSteelLatticeStrainData.Strain = random.Next(-350, 200);
                    }
                    else if (newSteelLatticeStrainData.Time.Hour >= 12 && newSteelLatticeStrainData.Time.Hour <= 14)
                    {
                        if (newSteelLatticeStrainData.Time.Minute == 17)
                        {
                            newSteelLatticeStrainData.Strain = random.Next(-520, 350);//可能红色报警
                        }
                        else
                        {
                            newSteelLatticeStrainData.Strain = random.Next(-350, 200);
                        }
                    }
                    else if (newSteelLatticeStrainData.Time.Hour >= 15 && newSteelLatticeStrainData.Time.Hour <= 16)
                    {
                        newSteelLatticeStrainData.Strain = random.Next(-350, 200);
                    }
                    else if (newSteelLatticeStrainData.Time.Hour >= 17 && newSteelLatticeStrainData.Time.Hour <= 19)
                    {
                        if (newSteelLatticeStrainData.Time.Minute == 17)
                        {
                            newSteelLatticeStrainData.Strain = random.Next(-520, 350);//可能红色报警
                        }
                        else
                        {
                            newSteelLatticeStrainData.Strain = random.Next(-350, 200);
                        }
                    }
                    else
                    {
                        newSteelLatticeStrainData.Strain = random.Next(-250, 150);
                    }
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
            double timeForCalculate;
            for (int i = startNumberOfTemperaturePoints; i <= endNumberOfTemperaturePoints; i++)
            {
                var newTemperatureData = new Original_TemperatureTable()
                {
                    PointsNumberId = i,
                    Time = DateTime.Now,
                };
                timeForCalculate = Convert.ToDouble(newTemperatureData.Time.Hour) + Convert.ToDouble(newTemperatureData.Time.Minute) / 60;
                if (newTemperatureData.PointsNumberId == 168)
                {
                    newTemperatureData.Temperature = Math.Round((0.0006688963 * Math.Pow(timeForCalculate, 4) - 0.0348599334 * Math.Pow(timeForCalculate, 3) + 0.5121538687 * Math.Pow(timeForCalculate, 2) - 1.3478253362 * timeForCalculate + 23.4826210826 + random.Next(-2, 2)),2);
                }
                else
                {
                    newTemperatureData.Temperature = Math.Round((-0.0000161352 * Math.Pow(timeForCalculate, 6) + 0.0013666675 * Math.Pow(timeForCalculate, 5) - 0.0419269504 * Math.Pow(timeForCalculate, 4) + 0.5518862571 * Math.Pow(timeForCalculate, 3) - 2.8402782982 * Math.Pow(timeForCalculate, 2) + 5.1969544638 * timeForCalculate + 11.6605128245 + random.Next(-2, 5)),2);

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
            double timeForCalculate;
            for (int i = startNumberOfWindLoadPoints; i <= endNumberOfWindLoadPoints; i++)
            {
                var newWindLoadData = new Original_WindLoadTable()
                {
                    PointsNumberId = i,
                    Time = DateTime.Now,
                };
                timeForCalculate = Convert.ToDouble(newWindLoadData.Time.Hour) + Convert.ToDouble(newWindLoadData.Time.Minute) / 60;

                newWindLoadData.WindSpeed = Math.Round((0.0000098798 * Math.Pow(timeForCalculate, 6) - 0.0006773310 * Math.Pow(timeForCalculate, 5) + 0.0168724697 * Math.Pow(timeForCalculate, 4) - 0.1791762231 * Math.Pow(timeForCalculate, 3) + 0.6505986426 * Math.Pow(timeForCalculate, 2) + 0.5279698407 * timeForCalculate + 10.2690913645 + random.Next(-2, 4)),2);

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
