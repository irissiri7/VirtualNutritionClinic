using NUnit.Framework;
using NutritionClinicLibrary;
using System;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void SettingUpNutritionClinic_DietitianAndPTIsCorrect()
        {
            //Setting up employees
            Dietitian sutDT = new Dietitian("sutDT", Employee.Positions.Dietitian);
            PersonalTrainer sutPT = new PersonalTrainer("sutPT", Employee.Positions.PersonalTrainer);
            //Setting up clinic
            NutritionClinic sutClinic = new NutritionClinic("sutClinic", sutDT, sutPT);
            
            Assert.AreEqual(sutDT, sutClinic.Dietitian);
            Assert.AreEqual(sutPT, sutClinic.PersonalTrainer);
        }

        [Test]
        public void ClientGenerator_NeverProducesTooUnderweightClient()
        {
            NutritionClinic sutClinic = SetUpTestClinic();
            for(int i = 0; i < 10000; i++)
            {
                Client sut = ClientGenerator.GenerateRandomClient(sutClinic);
                if(sut.BMI < 12)
                {
                    Assert.Fail();
                }
            }
            Assert.Pass();
        }

        [Test]
        public void ClientGenerator_NeverProducesNormalWeightClient()
        {
            NutritionClinic sutClinic = SetUpTestClinic();
            for (int i = 0; i < 10000; i++)
            {
                Client sut = ClientGenerator.GenerateRandomClient(sutClinic);
                if (sut.BMI > 18.5 && sut.BMI < 25)
                {
                    Assert.Fail();
                }
            }
            Assert.Pass();
        }

        [Test]
        public void NutritionClinic_SigningIn10000Patients_ClientRecordCountIsCorrect()
        {
            NutritionClinic sutClinic = SetUpTestClinic();
            SignIn10000Clients(sutClinic);
            Assert.AreEqual(10000, sutClinic.ClientRecord.Count);
        }

        [Test]
        public void NutritionClinic_SigningIn100001Patients_CurrentClientIsCorrect()
        {
            NutritionClinic sutClinic = SetUpTestClinic();
            SignIn10000Clients(sutClinic);
            
            Client newCurrentClient = new Client("Jane Doe", 1.7, 60, sutClinic.Dietitian, sutClinic.PersonalTrainer);
            sutClinic.SignInNewClient(newCurrentClient);
            
            Assert.AreEqual(sutClinic.CurrentClient, newCurrentClient);
        }
        
        [Test]
        public void SmoothieBar_Making10000Smoothies_NutritionValuesAreAlwaysCorrect()
        {
            Food testBanana = new Food("banana", 100, 100);

            for(int i = 0; i < 10000; i++)
            {
                Smoothie sutSmoothie = SmoothieBar.MakeSmoothie(testBanana, testBanana);
                if(sutSmoothie.KcalPerportion != 200)
                {
                    Assert.Fail();
                }
                if(sutSmoothie.ProteinPerportion != 200)
                {
                    Assert.Fail();
                }
            }

            Assert.Pass();
        }
        
        [Test]
        public void Client_UnderweightEvaluationJustUnderLimit_IsCorrect()
        {
            NutritionClinic sutClinic = SetUpTestClinic();
            Client sut = new Client("Jane Doe", 1.7, 53.3, sutClinic.Dietitian, sutClinic.PersonalTrainer); //Which should generate BMI 18.4
            Assert.IsTrue(sut.IsUnderWeight);
        }

        [Test]
        public void Client_UnderweightEvaluationRightOnTheEdge_IsCorrect()
        {
            NutritionClinic sutClinic = SetUpTestClinic();
            Client sut = new Client("Jane Doe", 1.7, 53.6, sutClinic.Dietitian, sutClinic.PersonalTrainer); //Which should generate BMI 18.5
            Assert.IsFalse(sut.IsUnderWeight);
        }

        [Test]
        public void Client_OverweightEvaluationRightOnTheEdge_IsCorrect()
        {
            NutritionClinic sutClinic = SetUpTestClinic();
            Client sut = new Client("Jane Doe", 1.7, 72.2, sutClinic.Dietitian, sutClinic.PersonalTrainer); //Which should generate BMI 25.0
            Assert.IsFalse(sut.IsOverWeight);
        }

        [Test]
        public void Client_OverweightEvaluationJustOverLimit_IsCorrect()
        {
            NutritionClinic sutClinic = SetUpTestClinic();
            Client sut = new Client("Jane Doe", 1.7, 72.4, sutClinic.Dietitian, sutClinic.PersonalTrainer); //Which should generate BMI 25.1
            Assert.IsTrue(sut.IsOverWeight);
        }

        public NutritionClinic SetUpTestClinic()
        {
            //Setting up employees
            Dietitian sutDT = new Dietitian("sutDT", Employee.Positions.Dietitian);
            PersonalTrainer sutPT = new PersonalTrainer("sutPT", Employee.Positions.PersonalTrainer);
            //Setting up clinic
            NutritionClinic sutClinic = new NutritionClinic("sutClinic", sutDT, sutPT);

            return sutClinic;
        }
        public void SignIn10000Clients(NutritionClinic sut)
        {
            for (int i = 0; i < 10000; i++)
            {
                sut.SignInNewClient(ClientGenerator.GenerateRandomClient(sut));
            }
        }
    }

    
}