template<typename T>
class $__Delegate__$ : public gc
{
protected :
	/// class FunctionInfo
	class FunctionInfo : public gc
	{
	public :
		FunctionInfo(const std::string& id, T function)
		{
			mID = id;
			mFunction = function;
		}

		const std::string&	getID() const		{ return mID; }
		const T&			getFunction() const	{ return mFunction; }

	private :
		std::string	mID;
		T			mFunction;
	};


	/// Type
	using FunctionInfoContainer = std::list<FunctionInfo*>;


	/// Ctor & Dtor
	$__Delegate__$()
	{
		clearFunctions();
	}

	$__Delegate__$(T function, void* object, const std::string& methodName)
	{
		clearFunctions();

		mFunctions.push_back(
			new FunctionInfo(generateID(object, methodName), function));
	}

	virtual ~$__Delegate__$()
	{
		clearFunctions();
	}


	/// Function
	void clearFunctions()
	{
		mFunctions.clear();
	}


	void addFunctions(const FunctionInfoContainer& source)
	{
		for (auto& item : source)
		{
			mFunctions.push_back(item);
		}
	}


	void removeFunction(const FunctionInfo* target)
	{
		for (auto it = mFunctions.rbegin(); it != mFunctions.rend(); ++it)
		{
			if ((*it)->getID() == target->getID())
			{
				mFunctions.erase(std::next(it).base());
				break;
			}
		}
	}


	static void addFunctions(FunctionInfoContainer& destination, const FunctionInfoContainer& source)
	{
		for (auto& item : source)
		{
			destination.push_back(item);
		}
	}


	/// Variable
	FunctionInfoContainer	mFunctions;


private :
	/// Function
	const std::string generateID(void* object, const std::string& methodName)
	{
		std::stringstream	id;

		id << std::hex << std::uppercase << std::setw(8) << std::setfill('0') << (int)object
			<< "." << methodName;

		return id.str();
	}
};
