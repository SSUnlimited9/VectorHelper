using Celeste;
using Monocle;

namespace VectorHelper.Entities
{
	public class ErrorEntity : Entity
	{
		private string message;

		/// <summary>
		/// Create an error postcard
		/// </summary>
		/// <param name="ErrorMessage">The error message that will show on the postcard</param>
		public ErrorEntity(string ErrorMessage)
		{
			message = ErrorMessage;
		}

		public override void Added(Scene scene)
		{
			Audio.SetMusic(null);
			LevelEnter.ErrorMessage = message;
			LevelEnter.Go(new Session(SceneAs<Level>().Session.Area), false);
		}
	}
}