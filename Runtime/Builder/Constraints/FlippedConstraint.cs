using System;

namespace Hybel
{
    public partial class Interpolate
    {
        public class FlippedConstraint<TBuilder, TBuildConstraint> : IModifierConstraint
            where TBuilder : IBuilder
            where TBuildConstraint : IBuildConstraint<TBuilder>
        {
            private readonly TBuilder _builder;
            private readonly float _threshold;
            private readonly EaseFunction _modifier;

            public FlippedConstraint(TBuilder builder, float threshold = 0f, EaseFunction modifier = null)
            {
                _builder = builder;
                _threshold = threshold;
                _modifier = modifier;
            }

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

            public EaseFunction GetEase() => t => Interpolate.Flip(_modifier?.Invoke(t) ?? t, _threshold);

            private TBuildConstraint CreateConstraint(EaseFunction easeFunc) =>
                (TBuildConstraint)Activator.CreateInstance(typeof(TBuildConstraint),
                    new object[] { _builder, (EaseFunction)(t => easeFunc(GetEase().Invoke(t))) });
        }
    }
}
