using System.Data.Entity;
using Coder.Core.Models.Commons;
using Coder.Core.Models.Functions;
using Coder.Core.Models.OnlineJudges;
using Coder.Core.Models.Solutions;
using Coder.Core.Models.MidTab;

namespace Coder.Data
{
    public class Db:DbContext
    {
        public Db()
        {
            Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<Db>());
        }

        public DbSet<CommentModel> comments{get;set;}
        public DbSet<CommonModel> commons{get;set;}
        public DbSet<CompanyModel> companies{get;set;}
        public DbSet<FeedbackModel> feddbacks{get;set;}
        public DbSet<InsideMessageModel> messages{get;set;}
        public DbSet<LevelModel> levels{get;set;}
        public DbSet<PowerModel> powers{get;set;}
        public DbSet<PowerViewModel> powerViews{get;set;}
        public DbSet<RuleModel> rules{get;set;}
        public DbSet<UserModel> users{get;set;}
        public DbSet<WealthModel> wealthes{get;set;}
        public DbSet<CodeModel> codes{get;set;}
        public DbSet<FunctionModel> functions{get;set;}
        public DbSet<FunctionPlateModel> functionPlates{get;set;}
        public DbSet<BaseProblemModel> baseProblems{get;set;}
        public DbSet<ContestPermissionModel> contestPermissions{get;set;}
        public DbSet<ListModel> lists{get;set;}
        public DbSet<ModelProblemModel> modelProblems{get;set;}
        public DbSet<ResultCodeModel> resultCodes{get;set;}
        public DbSet<ResultModel> results { get; set; }
        public DbSet<SingleContestModel> singleContests{get;set;}
        public DbSet<SingleResultModel> singleResults{get;set;}
        public DbSet<SourceModel> sources{get;set;}
        public DbSet<TeamContestModel> teamContests{get;set;}
        public DbSet<TeamModel> teams{get;set;}
        public DbSet<TeamResultModel> teamResults{get;set;}
        public DbSet<SolutionModel> solutions{get;set;}
        public DbSet<SolutionProblemModel> solutionProblems{get;set;}
        public DbSet<TypeModel> types{get;set;}
        public DbSet<BaseProblem_SingleContestModel> bp_sc { get; set; }
        public DbSet<BaseProblem_TeamContestModel> bp_tc { get; set; }
        public DbSet<User_SingleContestModel> u_sc { get; set; }
        public DbSet<User_TeamContestModel> u_tc { get; set; }
        public DbSet<User_TeamModel> u_t { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
