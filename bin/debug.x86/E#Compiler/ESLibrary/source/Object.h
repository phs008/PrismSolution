class $__Object__$ : public gc
{
public :
	$__Object__$()			= default;
	virtual ~$__Object__$()	= default;

	virtual const char* __GetClassName__()						{ return "$__Object__$"; }
	virtual unsigned int __GetFieldNum__()						{ return 0; }
	virtual const char* __GetFieldName__(unsigned int i)		{ return nullptr; }
	virtual const char* __GetFieldType__(unsigned int i)		{ return nullptr; }
	virtual const char* __GetFieldAccessor__(unsigned int i)	{ return nullptr; }

	virtual int __ReadField__ (string fieldName, void* ptr, int* len)				{ return 0; }
	virtual int __WriteField__(string fieldName, void* ptr, int len, int typeInfo)	{ return 0; }

protected :
	bool SeparateArrayFieldName(const string& fieldName, string& arrayFieldName, int& arrayIndex)
	{
		std::stringstream			ss(fieldName);
		std::vector<std::string>	tokens;
		std::string					item;

		/*
		comma version
		while (std::getline(ss, item, ','))
		{
			tokens.push_back(item);
		}

		if (tokens.size() >= 2)
		{
			arrayFieldName = tokens[0];

			try
			{
				arrayIndex = std::stoi(tokens[1]);
			}
			catch (std::exception& e)
			{
				arrayIndex = 0;
			}

			return true;
		}
		*/
		// [] version
		if (std::getline(ss, item, '['))
		{
			tokens.push_back(item);

			if (std::getline(ss, item, ']'))
			{
				tokens.push_back(item);
			}
			else
				return false;
		}
		else
		{
			return false;
		}

		if (tokens.size() >= 2)
		{
			arrayFieldName = tokens[0];

			try
			{
				arrayIndex = std::stoi(tokens[1]);
			}
			catch (std::exception& e)
			{
				arrayIndex = 0;
			}

			return true;
		}

		return false;
	}



};



