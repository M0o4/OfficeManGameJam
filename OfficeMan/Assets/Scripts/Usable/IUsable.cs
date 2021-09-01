using UnityEngine.InputSystem;

namespace Usable
{
   public interface IUsable
   {
      bool Used { get; set; }
      void Use(InputAction.CallbackContext ctx);
      void StopUse(InputAction.CallbackContext ctx);
   }
}
