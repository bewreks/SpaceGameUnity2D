using SpaceGame.Scripts.Models;

namespace SpaceGame.Scripts.Views {
    public class BaseView<M> : ModelContainter<M>
        where M : BaseModel
    {
        protected override void Initialize() {}
    }
}