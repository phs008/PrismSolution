namespace System
{

class Exception : public $__Object__$
{
public :
	Exception()	= default;
	Exception(const string& message)
	{
		mMessage = message;
	}

	const string&	GetMessage() const	{ return mMessage; }

private :
	string	mMessage;
};

}
