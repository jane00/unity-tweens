using ElRaccoone.Tweens.Core;
using UnityEngine;

namespace ElRaccoone.Tweens {
  public static class LocalScaleXTween {
    public static Tween<float> TweenLocalScaleX (this Component self, float to, float duration) =>
      self.gameObject.TweenLocalScaleX (to, duration);

    public static Tween<float> TweenLocalScaleX (this GameObject self, float to, float duration) =>
      self.AddComponent<Tween> ().Finalize (duration, to);

    private class Tween : Tween<float> {
      private Vector3 localScale;

      public override bool OnInitialize () {
        return true;
      }

      public override float OnGetFrom () {
        return this.transform.localScale.x;
      }

      public override void OnUpdate (float easedTime) {
        this.localScale = this.transform.localScale;
        this.valueCurrent = this.InterpolateValue (this.valueFrom, this.valueTo, easedTime);
        this.localScale.x = this.valueCurrent;
        this.transform.localScale = this.localScale;
      }
    }
  }
}