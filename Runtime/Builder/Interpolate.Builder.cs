namespace Hybel
{
    public partial class Interpolate
    {
        public static CombineBuilder Combine() => new CombineBuilder();
        public static SplitBuilder Split() => new SplitBuilder();

        public interface IBuilder
        {
            public EaseFunction Build();
        }

        public interface IBuildConstraint<TBuilder>
            where TBuilder : IBuilder
        {
            public TBuilder In();
            public TBuilder Out();
            public EaseFunction InOut();
        }

        public interface IModifierConstraint
        {
            public EaseFunction GetEase();
        }

        public class SplitBuilder : IBuilder
        {
            private readonly float _split;
            private EaseFunction _in;
            private EaseFunction _out;

            public SplitBuilder(float split = .5f) => _split = split;

            public SpikedConstraint<SplitBuilder, SplitConstraint> Spike(float bias = .5f, int spikes = 1) => new SpikedConstraint<SplitBuilder, SplitConstraint>(this, bias, spikes);
            public FlippedConstraint<SplitBuilder, SplitConstraint> Flip(float threshold) => new FlippedConstraint<SplitBuilder, SplitConstraint>(this, threshold);
            public WrappedConstraint<SplitBuilder, SplitConstraint> Wrap() => new WrappedConstraint<SplitBuilder, SplitConstraint>(this);
            public ZoomConstraint<SplitBuilder, SplitConstraint> Zoom(float zoom = 1f) => new ZoomConstraint<SplitBuilder, SplitConstraint>(this, zoom);
            public ScaledConstraint<SplitBuilder, SplitConstraint> Scale(float scale = 1f) => new ScaledConstraint<SplitBuilder, SplitConstraint>(this, scale);

            public SplitConstraint Round() => new SplitConstraint(this, Interpolate.Clamp);
            public SplitConstraint Linear() => new SplitConstraint(this, Interpolate.Linear);
            public SplitConstraint Sine() => new SplitConstraint(this, Interpolate.SineIn);
            public SplitConstraint Quad() => new SplitConstraint(this, Interpolate.QuadIn);
            public SplitConstraint Cube() => new SplitConstraint(this, Interpolate.CubeIn);
            public SplitConstraint Quart() => new SplitConstraint(this, Interpolate.QuartIn);
            public SplitConstraint Quint() => new SplitConstraint(this, Interpolate.QuintIn);
            public SplitConstraint Sext() => new SplitConstraint(this, Interpolate.SextIn);
            public SplitConstraint Sept() => new SplitConstraint(this, Interpolate.SeptIn);
            public SplitConstraint Oct() => new SplitConstraint(this, Interpolate.OctIn);
            public SplitConstraint Expo() => new SplitConstraint(this, Interpolate.ExpoIn);
            public SplitConstraint Circ() => new SplitConstraint(this, Interpolate.CircIn);
            public SplitConstraint Back() => new SplitConstraint(this, Interpolate.BackIn);
            public SplitConstraint Elastic() => new SplitConstraint(this, Interpolate.ElasticIn);
            public SplitConstraint Bounce() => new SplitConstraint(this, Interpolate.BounceIn);
            public SplitConstraint Triangle() => new SplitConstraint(this, Interpolate.Triangle);
            public SplitConstraint SmoothStep() => new SplitConstraint(this, Interpolate.SmoothStep);
            public SplitConstraint Ease(Ease ease) => new SplitConstraint(this, GetEaseSimple(ease));

            public EaseFunction Build() => Split();

            private EaseFunction Split()
            {
                return t =>
                {
                    if ((t % 1) <= _split)
                        return _in(t);

                    return _out(t);
                };
            }

            public static implicit operator EaseFunction(SplitBuilder builder) => builder.Build();

            public class SplitConstraint : IBuildConstraint<SplitBuilder>
            {
                private readonly SplitBuilder _builder;
                private readonly EaseFunction _ease;

                public SplitConstraint(SplitBuilder builder, EaseFunction ease)
                {
                    _builder = builder;
                    _ease = ease;
                }

                public SplitBuilder In()
                {
                    _builder._in = _ease;
                    return _builder;
                }

                public SplitBuilder Out()
                {
                    _builder._out = t => Interpolate.Flip(_ease(Interpolate.Flip(t)));
                    return _builder;
                }

                public EaseFunction InOut()
                {
                    _builder._in = _ease;
                    _builder._out = _ease;
                    return _builder.Build();
                }

                public static implicit operator EaseFunction(SplitConstraint constraint) => constraint.InOut();
            }
        }

        public class CombineBuilder : IBuilder
        {
            private EaseFunction _in;
            private EaseFunction _out;

            public WrappedConstraint<CombineBuilder, CombineConstraint> Wrap() => new WrappedConstraint<CombineBuilder, CombineConstraint>(this);
            public SpikedConstraint<CombineBuilder, CombineConstraint> Spike(float bias = .5f, int spikes = 1) => new SpikedConstraint<CombineBuilder, CombineConstraint>(this, bias, spikes);
            public FlippedConstraint<CombineBuilder, CombineConstraint> Flip(float threshold = 0f) => new FlippedConstraint<CombineBuilder, CombineConstraint>(this, threshold);
            public ZoomConstraint<CombineBuilder, CombineConstraint> Zoom(float zoom = 1f) => new ZoomConstraint<CombineBuilder, CombineConstraint>(this, zoom);
            public ScaledConstraint<CombineBuilder, CombineConstraint> Scale(float scale = 1f) => new ScaledConstraint<CombineBuilder, CombineConstraint>(this, scale);

            public CombineConstraint Round() => new CombineConstraint(this, Interpolate.Clamp);
            public CombineConstraint Linear() => new CombineConstraint(this, Interpolate.Linear);
            public CombineConstraint Sine() => new CombineConstraint(this, Interpolate.SineIn);
            public CombineConstraint Quad() => new CombineConstraint(this, Interpolate.QuadIn);
            public CombineConstraint Cube() => new CombineConstraint(this, Interpolate.CubeIn);
            public CombineConstraint Quart() => new CombineConstraint(this, Interpolate.QuartIn);
            public CombineConstraint Quint() => new CombineConstraint(this, Interpolate.QuintIn);
            public CombineConstraint Sext() => new CombineConstraint(this, Interpolate.SextIn);
            public CombineConstraint Sept() => new CombineConstraint(this, Interpolate.SeptIn);
            public CombineConstraint Oct() => new CombineConstraint(this, Interpolate.OctIn);
            public CombineConstraint Expo() => new CombineConstraint(this, Interpolate.ExpoIn);
            public CombineConstraint Circ() => new CombineConstraint(this, Interpolate.CircIn);
            public CombineConstraint Back() => new CombineConstraint(this, Interpolate.BackIn);
            public CombineConstraint Elastic() => new CombineConstraint(this, Interpolate.ElasticIn);
            public CombineConstraint Bounce() => new CombineConstraint(this, Interpolate.BounceIn);
            public CombineConstraint Triangle() => new CombineConstraint(this, Interpolate.Triangle);
            public CombineConstraint SmoothStep() => new CombineConstraint(this, Interpolate.SmoothStep);
            public CombineConstraint Ease(Ease ease) => new CombineConstraint(this, GetEaseSimple(ease));

            public EaseFunction Build() => t => Scalar(_in(t), _out(t), t);

            public static implicit operator EaseFunction(CombineBuilder builder) => builder.Build();

            public class CombineConstraint : IBuildConstraint<CombineBuilder>
            {
                private readonly CombineBuilder _builder;
                private readonly EaseFunction _ease;

                public CombineConstraint(CombineBuilder builder, EaseFunction ease)
                {
                    _builder = builder;
                    _ease = ease;
                }

                public CombineBuilder In()
                {
                    _builder._in = _ease;
                    return _builder;
                }

                public CombineBuilder Out()
                {
                    _builder._out = t => Interpolate.Flip(_ease(Interpolate.Flip(t)));
                    return _builder;
                }

                public EaseFunction InOut()
                {
                    _builder._in = _ease;
                    _builder._out = _ease;
                    return _builder.Build();
                }

                public static implicit operator EaseFunction(CombineConstraint constraint) => constraint.InOut();
            }
        }

        private static EaseFunction GetEaseSimple(Ease ease)
        {
            return ease switch
            {
                Hybel.Ease.Clamp => Clamp,
                Hybel.Ease.Linear => Linear,
                Hybel.Ease.SineIn or Hybel.Ease.SineOut or Hybel.Ease.SineInOut => SineIn,
                Hybel.Ease.QuadIn or Hybel.Ease.QuadOut or Hybel.Ease.QuadInOut => QuadIn,
                Hybel.Ease.CubeIn or Hybel.Ease.CubeOut or Hybel.Ease.CubeInOut => CubeIn,
                Hybel.Ease.QuartIn or Hybel.Ease.QuartOut or Hybel.Ease.QuartInOut => QuartIn,
                Hybel.Ease.QuintIn or Hybel.Ease.QuintOut or Hybel.Ease.QuintInOut => QuintIn,
                Hybel.Ease.SextIn or Hybel.Ease.SextOut or Hybel.Ease.SextInOut => SextIn,
                Hybel.Ease.SeptIn or Hybel.Ease.SeptOut or Hybel.Ease.SeptInOut => SeptIn,
                Hybel.Ease.OctIn or Hybel.Ease.OctOut or Hybel.Ease.OctInOut => OctIn,
                Hybel.Ease.ExpoIn or Hybel.Ease.ExpoOut or Hybel.Ease.ExpoInOut => ExpoIn,
                Hybel.Ease.CircIn or Hybel.Ease.CircOut or Hybel.Ease.CircInOut => CircIn,
                Hybel.Ease.BackIn or Hybel.Ease.BackOut or Hybel.Ease.BackInOut => BackIn,
                Hybel.Ease.ElasticIn or Hybel.Ease.ElasticOut or Hybel.Ease.ElasticInOut => ElasticIn,
                Hybel.Ease.BounceIn or Hybel.Ease.BounceOut or Hybel.Ease.BounceInOut => BounceIn,
                Hybel.Ease.Triangle => Triangle,
                Hybel.Ease.SmoothStep => SmoothStep,
                _ => Linear,
            };
        }
    }
}
