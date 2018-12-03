using SpaceGame.Scripts.Models;

namespace SpaceGame.Scripts.Controllers {
    public class BaseController<M> : ModelContainter<M>
        where M : BaseModel
    {
        protected override void Initialize() {}
    }
}