using System;
using UnityEngine;

namespace Hybel
{
    public partial class Interpolate
    {
        public class SpikedConstraint<TBuilder, TBuildConstraint> : IModifierConstraint
            where TBuilder : IBuilder
            where TBuildConstraint : IBuildConstraint<TBuilder>
        {
            private readonly TBuilder _builder;
            private readonly float _bias;
            private readonly int _spikes;
            private readonly EaseFunction _modifier;

            public SpikedConstraint(TBuilder builder, float bias = .5f, int spikes = 1, EaseFunction modifier = null)
            {
                _builder = builder;
                _bias = bias;
                _spikes = Mathf.Abs(spikes);
                _modifier = modifier;
            }

            public FlippedConstraint<TBuilder, TBuildConstraint> Flip(float threshold = 0f) =>
                new FlippedConstraint<TBuilder, TBuildConstraint>(_builder, threshold, GetEase());

            public ZoomConstraint<TBuilder, TBuildConstraint> Zoom(float zoom = 1) =>
                new ZoomConstraint<TBuilder, TBuildConstraint>(_builder, zoom, GetEase());

            public ScaledConstraint<TBuilder, TBuildConstraint> Scale(float scale = 1) =>
                new ScaledConstraint<TBuilder, TBuildConstraint>(_builder, scale, GetEase());

            public TBuildConstraint Round() => CreateConstraint(Interpolate.Clamp);
            public TBuildConstraint Linear() => CreateConstraint(Interpolate.Linear);
            public TBuildConstraint Sine() => CreateConstraint(Interpolate.SineIn);
            public TBuildConstraint Quad() => CreateConstraint(Interpolate.QuadIn);
            public TBuildConstraint Cube() => CreateConstraint(Interpolate.CubeIn);
            public TBuildConstraint Quart() => CreateConstraint(Interpolate.QuartIn);
            public TBuildConstraint Quint() => CreateConstraint(Interpolate.QuintIn);
            public TBuildConstraint Sext() => CreateConstraint(Interpolate.SextIn);
            public TBuildConstraint Sept() => CreateConstraint(Interpolate.SeptIn);
            public TBuildConstraint Oct() => CreateConstraint(Interpolate.OctIn);
            public TBuildConstraint Expo() => CreateConstraint(Interpolate.ExpoIn);
            public TBuildConstraint Circ() => CreateConstraint(Interpolate.CircIn);
            public TBuildConstraint Back() => CreateConstraint(Interpolate.BackIn);
            public TBuildConstraint Elastic() => CreateConstraint(Interpolate.ElasticIn);
            public TBuildConstraint Bounce() => CreateConstraint(Interpolate.BounceIn);
            public TBuildConstraint Triangle() => CreateConstraint(Interpolate.Triangle);
            public TBuildConstraint SmoothStep() => CreateConstraint(Interpolate.SmoothStep);

            public EaseFunction GetEase() => t => Interpolate.Spiked(_modifier?.Invoke(t) ?? t, _bias, _spikes);

            private TBuildConstraint CreateConstraint(EaseFunction easeFunc) =>
                (TBuildConstraint)Activator.CreateInstance(typeof(TBuildConstraint),
                    new object[] { _builder, (EaseFunction)(t => easeFunc(GetEase().Invoke(t))) });
        }
    }
}
