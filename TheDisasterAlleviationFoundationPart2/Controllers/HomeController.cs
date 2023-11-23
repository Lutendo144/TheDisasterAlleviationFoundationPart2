using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Security.Policy;
using TheDisasterAlleviationFoundationPart2.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TheDisasterAlleviationFoundationPart2.Controllers
{
    public class HomeController : Controller
    {
        public string connectionString = "Server=tcp:st10105269.database.windows.net,1433;Initial Catalog = DJPromoDatabase; Persist Security Info=False;User ID = djadmin; Password=Lutendo144;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;";

        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //signup
        [HttpPost]
        public IActionResult signup(Users users)
        {
            SqlCommand com;
            string connectionstring = "Server=tcp:st10105269.database.windows.net,1433;Initial Catalog=DJPromoDatabase;Persist Security Info=False;User ID=djadmin;Password=Lutendo144;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlConnection cnt = new SqlConnection(connectionstring);
            cnt.Open();//open connection
            string query = "INSERT INTO Users (FirstName,LastName,UserName,Password) VALUES (@FirstName,@LastName,@UserName,@Password)";
            com = new SqlCommand(query, cnt);//using the command 


            com.Parameters.AddWithValue("@FirstName", users.FirstName);
            com.Parameters.AddWithValue("@LastName", users.LastName);
            com.Parameters.AddWithValue("@UserName", users.UserName);
            com.Parameters.AddWithValue("@Password", users.Password);


            com.ExecuteNonQuery();
            cnt.Close();//Close connecting
            return View("login");
        }

        [HttpGet]
        public IActionResult signup()
        {
            return View();
        }

        //login
        [HttpPost]
        public IActionResult login(Users user)
        {
            string connectionstring = "Server=tcp:st10105269.database.windows.net,1433;Initial Catalog=DJPromoDatabase;Persist Security Info=False;User ID=djadmin;Password=Lutendo144;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


            using (SqlConnection cnt = new SqlConnection(connectionstring))
            {
                cnt.Open();

                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                SqlCommand com = new SqlCommand(query, cnt);
                com.Parameters.AddWithValue("@Username", user.UserName);
                com.Parameters.AddWithValue("@Password", user.Password);

                int count = (int)com.ExecuteScalar();

                if (count > 0)
                {
                    // Successful login, redirect to a dashboard or another page
                    return RedirectToAction("Index");
                }
                else
                {
                    // Invalid login, return to the login page with an error message
                    ModelState.AddModelError(string.Empty, "Invalid credentials");
                    return View("login");
                }
            }
        }

        [HttpGet]
        public IActionResult login()
        {
            return View();
        }

        //MonetaryDonations
        [HttpPost]
        public IActionResult MonetaryDonations(MonetaryDonations goods)
        {
            SqlCommand cmd;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "INSERT INTO MonetaryDonations (DonationDate, Amount, DonorName, IsAnonymous) VALUES (@DonationDate, @Amount, @DonorName, @IsAnonymous)";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@DonationDate", goods.DonationDate);
            cmd.Parameters.AddWithValue("@Amount", goods.Amount);
            cmd.Parameters.AddWithValue("@DonorName", goods.DonorName);
            cmd.Parameters.AddWithValue("@IsAnonymous", goods.IsAnonymous);
            cmd.ExecuteNonQuery();
            conn.Close();


            return View("ThankYou");
        }

        [HttpGet]
        public ActionResult MonetaryDonations()
        {
            return View();
        }

        //GoodsDonations
        [HttpPost]
        public IActionResult GoodsDonations(GoodsDonations goods)
        {
            SqlCommand cmd;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "INSERT INTO GoodsDonations (DonationDate, NumberOfItems, Description,DonorName, IsAnonymous) VALUES (@DonationDate, @NumberOfItems, @Description,@DonorName, @IsAnonymous)";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@DonationDate", goods.DonationDate);
            cmd.Parameters.AddWithValue("@NumberOfItems", goods.NumberOfItems);
            cmd.Parameters.AddWithValue("@Description", goods.Description);
            cmd.Parameters.AddWithValue("@DonorName", goods.DonorName);
            cmd.Parameters.AddWithValue("@IsAnonymous", goods.IsAnonymous);
            cmd.ExecuteNonQuery();
            conn.Close();


            return View("ThankYou");
        }

        [HttpGet]
        public ActionResult GoodsDonations()
        {
            return View();
        }

        //GoodsCategories
        [HttpPost]
        public IActionResult GoodsCategories(GoodsCategories goods)
        {
            SqlCommand cmd;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "INSERT INTO GoodsCategories (CategoryName) VALUES (@CategoryName)";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@CategoryName", goods.CategoryName);
            cmd.ExecuteNonQuery();
            conn.Close();


            return View("ThankYou");
        }

        [HttpGet]
        public ActionResult GoodsCategories()
        {
            return View();
        }

        //Disasters
        [HttpPost]
        public IActionResult Disasters(Disasters goods)
        {
            SqlCommand cmd;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "INSERT INTO Disasters (StartDate, EndDate, Location,Description, RequiredAidTypes) VALUES (@StartDate, @EndDate, @Location,@Description, @RequiredAidTypes)";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@StartDate", goods.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", goods.EndDate);
            cmd.Parameters.AddWithValue("@Location", goods.Location);
            cmd.Parameters.AddWithValue("@Description", goods.Description);
            cmd.Parameters.AddWithValue("@RequiredAidTypes", goods.RequiredAidTypes);
            cmd.ExecuteNonQuery();
            conn.Close();


            return View("ThankYou");
        }


        [HttpGet]
        public ActionResult Disasters()
        {
            return View();
        }

        //list MonetaryDonationsview
        public IActionResult MonetaryDonationsview()
        {
            List<MonetaryDonations> MonetaryDonations = new List<MonetaryDonations>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM MonetaryDonations";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Map the data to a MonetaryDonation model
                            MonetaryDonations donation = new MonetaryDonations
                            {
                                DonationID = (int)reader["DonationID"],
                                DonorName = reader["DonorName"].ToString(),
                                DonationDate = (DateTime)reader["DonationDate"],
                                Amount = (decimal)reader["Amount"],
                                // Map other properties
                            };

                            MonetaryDonations.Add(donation);
                        }
                    }
                }
            }

            return View(MonetaryDonations);
        }



        //list Disastersview
        public IActionResult Disastersview()
        {
            List<Disasters> Disasters = new List<Disasters>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM Disasters";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Map the data to a MonetaryDonation model
                            Disasters donation = new Disasters
                            {
                                StartDate = (DateTime)reader["StartDate"],
                                EndDate = (DateTime)reader["EndDate"],
                                Location = reader["Location"].ToString(),
                                Description = reader["Description"].ToString(),
                                RequiredAidTypes = reader["RequiredAidTypes"].ToString(),
                                // Map other properties
                            };

                            Disasters.Add(donation);
                        }
                    }
                }
            }

            return View(Disasters);
        }

        //list GoodsDonationsview
        public IActionResult GoodsDonationsview()
        {
            List<GoodsDonations> GoodsDonations = new List<GoodsDonations>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM GoodsDonations";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            GoodsDonations donation = new GoodsDonations
                            {
                                DonationDate = (DateTime)reader["DonationDate"],
                                NumberOfItems = (int)reader["NumberOfItems"],
                                Description = reader["Description"].ToString(),
                                DonorName = reader["DonorName"].ToString(),

                            };

                            GoodsDonations.Add(donation);
                        }
                    }
                }
            }

            return View(GoodsDonations);
        }



        //Allocation
        [HttpPost]
        public IActionResult Allocation(Allocation viewModel)
        {


            SqlCommand cmd;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string query = "INSERT INTO Allocation (AllocationAmount, AllocationCategory ) VALUES (@Amount, @AllocationCategory )";
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Amount", viewModel.AllocationAmount);
            cmd.Parameters.AddWithValue("@AllocationCategory", viewModel.AllocationCategory);

            decimal allocatedAmount = viewModel.AllocationAmount;

            // Calculate the updated available money
            decimal updatedAvailableMoney = allocatedAmount;


            ViewData["UpdatedAvailableMoney"] = updatedAvailableMoney;

            cmd.ExecuteNonQuery();
            conn.Close();

            return View("Index");
        }

        [HttpGet]
        public ActionResult Allocation()
        {
            return View();
        }



        //GoodsAllocation
        [HttpPost]
        public IActionResult GoodsAllocation(GoodsAllocation viewModel)
        {
            SqlCommand cmd;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string query = "INSERT INTO GoodsAllocation (Location, TypeOfDisaster, GoodsDescription) VALUES (@Location, @TypeOfDisaster, @GoodsDescription)";
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Location", viewModel.Location);
            cmd.Parameters.AddWithValue("@TypeOfDisaster", viewModel.TypeOfDisaster);
            cmd.Parameters.AddWithValue("@GoodsDescription", viewModel.GoodsDescription);

            cmd.ExecuteNonQuery();
            conn.Close();

            return View("Index");
        }

        [HttpGet]
        public ActionResult GoodsAllocation()
        {
            return View();
        }


        //Purchase

        [HttpPost]
        public IActionResult Purchase(Purchase purchase)
        {
            // Calculate the available money from Allocation
            decimal availableMoney = CalculateAvailableMoney();

            if (purchase.Amount > availableMoney)
            {
                // Handle the case where the purchase amount exceeds the available money
                return RedirectToAction("PurchaseExceedsAvailableMoney");
            }

            // Continue with capturing the purchase
            SqlCommand cmd;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string query = "INSERT INTO Purchase (Amount, Description, DisasterId) VALUES (@Amount, @Description, @DisasterId)";
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Amount", purchase.Amount);
            cmd.Parameters.AddWithValue("@Description", purchase.Description);
            cmd.Parameters.AddWithValue("@DisasterId", purchase.DisasterId);

            cmd.ExecuteNonQuery();
            conn.Close();

            // Update the available money (decrease it by the purchase amount)
            UpdateAvailableMoney(availableMoney - purchase.Amount);



            decimal updatedAvailableMoney = availableMoney - purchase.Amount;

            ViewBag.UpdatedAvailableMoney = updatedAvailableMoney;


            return View("PurchaseSuccessful");


            decimal CalculateAvailableMoney()
            {
                decimal availableMoney = 10000;


                return availableMoney;
            }
        }

        public IActionResult PurchaseExceedsAvailableMoney()
        {
            return View();
        }




        private void UpdateAvailableMoney(decimal newAmount)
        {

        }

        [HttpGet]
        public ActionResult Purchase()
        {
            return View();
        }




        public IActionResult DonationManager()
        {
            decimal totalMonetaryDonationsReceived;
            int totalGoodsReceived;
            decimal moneyallocated;
            string TypeOfDisaster = "";
            string GoodsDescription = "";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Calculate total monetary donations
                string monetaryQuery = "SELECT SUM(Amount) FROM MonetaryDonations";
                using (SqlCommand monetaryCmd = new SqlCommand(monetaryQuery, conn))
                {
                    totalMonetaryDonationsReceived = Convert.ToDecimal(monetaryCmd.ExecuteScalar());
                }

                // Calculate total goods received
                string goodsQuery = "SELECT SUM(NumberOfItems) FROM GoodsDonations";
                using (SqlCommand goodsCmd = new SqlCommand(goodsQuery, conn))
                {
                    totalGoodsReceived = Convert.ToInt32(goodsCmd.ExecuteScalar());
                }

                // Calculate total goods received
                string moneyQuery = "SELECT SUM(AllocationAmount) FROM Allocation";
                using (SqlCommand moneyCmd = new SqlCommand(moneyQuery, conn))
                {
                    moneyallocated = Convert.ToDecimal(moneyCmd.ExecuteScalar());
                }

                // Fetch the description from the latest disaster
                string disasterQuery = "SELECT TypeOfDisaster FROM GoodsAllocation";
                using (SqlCommand disasterCmd = new SqlCommand(disasterQuery, conn))
                {
                    object disasterDescriptionObj = disasterCmd.ExecuteScalar();
                    TypeOfDisaster = disasterDescriptionObj != null ? disasterDescriptionObj.ToString() : "";
                }

                // Fetch the description from the latest disaster
                string GoodsDescriptionQuery = "SELECT GoodsDescription FROM GoodsAllocation";
                using (SqlCommand GoodsDescriptionCmd = new SqlCommand(GoodsDescriptionQuery, conn))
                {
                    object GoodsDescriptionObj = GoodsDescriptionCmd.ExecuteScalar();
                    GoodsDescription = GoodsDescriptionObj != null ? GoodsDescriptionObj.ToString() : "";
                }
            }

                // Pass the information to the view
                ViewData["TotalMonetaryDonationsReceived"] = (int)totalMonetaryDonationsReceived;
            ViewData["TotalGoodsReceived"] = totalGoodsReceived;
            ViewData["moneyallocated"] = moneyallocated;
            ViewData["TypeOfDisaster"] = TypeOfDisaster;
            ViewData["GoodsDescription"] = GoodsDescription;


            return View();
        }

        // ... other actions ...

    }
}
