using System;
using System.ComponentModel.DataAnnotations;

namespace Prudena.Web.Models
{
 
    public class LendingClubLoan
    {

        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public bool SentToGAIuSForLearning { get; set; }

        public string RawTrainingResults { get; set; }
        public DateTime? SentToGAIuSForLearningDate { get; set; }

        //[Index(IsUnique = true)]
        [Required]
        [StringLength(200)]
        public string LoanID { get; set; }

        public string MemberID { get; set; }

        public double LoanAmount { get; set; }

        public double FundedAmount { get; set; }

        public double RemainingAmount { get; set; }

        public double FundedPercentage { get { return this.FundedAmount / this.LoanAmount; } }

        public double FundedAmountInvestors { get; set; }

        public string Term { get; set; }

        public double InterestRate { get; set; }

        public double Installment { get; set; }

        public string Grade { get; set; }

        public string SubGrade { get; set; }

        public string EmployerTitle { get; set; }

        public string EmploymentLength { get; set; }

        public string HomeOwnership { get; set; }

        public double AnnualIncome { get; set; }
        public string VerificationStatus { get; set; }

        public DateTime? IssueDate { get; set; }

        public string LoanStatus { get; set; }

        public string PaymentPlan { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public string Purpose { get; set; }

        public string Title { get; set; }

        public string ZipCode { get; set; }

        public string AddressState { get; set; }

        public double? DebtToIncome { get; set; }

        public int? DelinquentTwoYears { get; set; }

        public string EarliestCreditLine { get; set; }

        public int? FicoRangeLow { get; set; }

        public int? FicoRangeHigh { get; set; }

        public int? InquiriesLastSixMonths { get; set; }

        public int? MonthsSinceLastDelinquency { get; set; }

        public int? MonthsSinceLastPublicRecord { get; set; }

        public int? OpenAccounts { get; set; }

        public int? NumberOfDerogatoryPublicRecords { get; set; }

        public double? TotalCreditRevolvingBalance { get; set; }

        public double? RevolvingLineUtilizationRate { get; set; }

        public int? TotalNumberOfCreditLines { get; set; }

        public string InitialListingStatusOfLoan { get; set; }

        public double OutstandingPrincipal { get; set; }

        public double OutstandingPrincipalInvestors { get; set; }

        public double TotalPayment { get; set; }

        public double TotalPaymentInvestors { get; set; }

        public double TotalPrincipalReceived { get; set; }

        public double TotalInterestReceived { get; set; }

        public double TotalLateFeeReceived { get; set; }

        public double Recoveries { get; set; }

        public double CollectionRecoveryFee { get; set; }

        public string LastPaymentDate { get; set; }

        public string NextPaymentDate { get; set; }


        public double LastPaymentAmount { get; set; }

        public string LastCreditPullDate { get; set; }

        public int? LastFicoRangeHigh { get; set; }

        public int? LastFicoRangeLow { get; set; }

        public double? CollectionsLastTwelveMonthExMedical { get; set; }

        public int? MonthsSinceLastMajorDerogatoryRating { get; set; }

        public string PolicyCode { get; set; }

        public double ExpectedDefaultRate { get; set; }

        public string ListingDate { get; set; }



        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }


        public double ScoreAll { get; set; }
        public double ScoreAllPositive { get; set; }
        public double ScoreAllNegative { get; set; }

        public double ScoreAllPercentage { get; set; }
        public double Score5 { get; set; }
        public double Score5Positive { get; set; }
        public double Score5Negative { get; set; }

        public double Score5Percentage { get; set; }


        public double Score10 { get; set; }
        public double Score10Positive { get; set; }
        public double Score10Negative { get; set; }

        public double Score10Percentage { get; set; }

        public double Score30 { get; set; }
        public double Score30Positive { get; set; }
        public double Score30Negative { get; set; }

        public double Score30Percentage { get; set; }

        public bool SentToGAIuSForPredictions { get; set; }

        public string RawPredictionResults { get; set; }
        public DateTime? SentToGAIuSForPredictionsDate { get; set; }

        public bool ListingIsCurrent { get; set; }

    }
}