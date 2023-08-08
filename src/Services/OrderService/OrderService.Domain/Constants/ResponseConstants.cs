using OrderService.Domain.Models.ConstantModels;

namespace OrderService.Domain.Constants
{
    /*
     * Fail message codes are between 02001 and 02999
     * Successful message codes are between 12001 and 12999
     */
    public static class ResponseConstants
    {
        #region Successful messages
        public static readonly ResponseConstantModel CreatingProcessSuccessful = new("12001", "Successfully created!");

        public static readonly ResponseConstantModel UpdatingProcessSuccessful = new("12002", "Successfully updated!");

        public static readonly ResponseConstantModel DeletingProcessSuccessful = new("12003", "Successfully deleted!");
        #endregion


        #region Fail messages
        public static readonly ResponseConstantModel CreatingProcessUnsuccessful = new("02001", "Failed to create! Please try again.");

        public static readonly ResponseConstantModel UpdatingProcessUnsuccessful = new("02002", "Failed to update! Please try again.");

        public static readonly ResponseConstantModel DeletingProcessUnsuccessful = new("02003", "Failed to delete! Please try again.");

        public static readonly ResponseConstantModel OrdersNotAvailable = new("02004", "There is no such orders!");

        #endregion
    }
}