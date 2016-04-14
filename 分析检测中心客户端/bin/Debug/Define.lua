AppMode="";	

ConnTable={}
ConnTable[0]=
{
	Name="服务器";
	IsOfficial=true;	
	ConnStr="Provider=SQLOLEDB;Data Source=server-1;Initial Catalog=CAT_JUST;";
}
ConnTable[1]=
{
	Name="服务器(IP模式)";
	IsOfficial=true;	
	ConnStr="Provider=SQLOLEDB;Data Source=218.87.136.231;Initial Catalog=CAT_JXUST;";

}

ConnTable[2]=
{
	Name="Debug模式";
	IsOfficial=true;	
	ConnStr="Provider=SQLOLEDB;Data Source=.;Initial Catalog=CAT_JXUST;Persist Security Info=True;";

}

