namespace SM.ViewModels
{
    /// <summary>
    /// Defines the view to display a Student
    /// </summary>
    public interface IStudentView
    {
        /// <summary>
        ///
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string SchoolType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string Gender { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string LastModifiedDate { get; set; }
    }
}
