template <typename T>
class $__Parameters__$ : public gc
{
public :
	$__Parameters__$()			= default;
	$__Parameters__$(std::initializer_list<T> params) : mParams(params)	{ }
	virtual ~$__Parameters__$()	= default;

	T& operator[](std::size_t idx)				{ return mParams[idx]; }
	const T& operator[](std::size_t idx) const	{ return mParams[idx]; }

private :
	std::vector<T>	mParams;
};
