temp={	--模板定位数据
x1=4;
y1={0,1,3,5,7,9,11,12,14,15,17};	--对应写数据的地方
x2=29;
namex=30;
datay=3;


rptpf={
	project="配分";
	gb="GB/T 18882.1-2008";
	weight="0.3000";
	ming="";
	ping="";
	v="100";
	rate="10";
};

rptal={
	project="Al2O3";
	gb="GB/T 18882.2-2008";
	weight="0.1000";
	ming="";
	ping="";
	v="100";
	rate="/";
};

rptpure={
	project="纯度";
	gb="GB/T 18115.{0}-2006";	
	weight="0.5000";
	ming="";
	ping="";
	v="100.00";
	rate="/";
};

rptca={
	project="CaO";
	gb="GB/T 12690.15-2006";
	weight="0.5000";
	ming="";
	ping="";
	v="50.00";
	rate="/";
}

}



ys={};	--元素配置


ys.La={
	Name="La";
	ICPName="La 408.671";
	RPTOName="La2O3";
	SQLName="La/TRE";
	SQLOName="La2O3/TREO";
	rate=0.8529;
	re=138.905;
	reo=162.905;
	isxtys=TRUE;
}

ys.Ce={
	Name="Ce";
	ICPName="Ce 413.380";
	RPTOName="CeO2";
	SQLName="Ce/TRE";
	SQLOName="CeO2/TREO";
	rate=0.8141;
	re=140.12;
	reo=172.12;
	isxtys=TRUE;
}

ys.Pr={
	Name="Pr";
	ICPName="Pr 405.653";
	RPTOName="Pr6O11";
	SQLName="Pr/TRE";
	SQLOName="Pr6O11/TREO";
	rate=0.8277;
	re=140.91;
	reo=170.2433333;
	isxtys=TRUE;
}


ys.Nd={
	Name="Nd";
	ICPName="Nd 401.224";
	RPTOName="Nd2O3";
	SQLName="Nd/TRE";
	SQLOName="Nd2O3/TREO";
	rate=0.8573;
	re=144.2;
	reo=168.2;
	isxtys=TRUE;
}


ys.Sm={
	Name="Sm";
	ICPName="Sm 443.432";
	RPTOName="Sm2O3";
	SQLName="Sm/TRE";
	SQLOName="Sm2O3/TREO";
	rate=0.8624;
	re=150.4;
	reo=174.4;
	isxtys=TRUE;
	}


ys.Eu={
	Name="Eu";
	ICPName="Eu 412.972";
	RPTOName="Eu2O3";
	SQLName="Eu/TRE";
	SQLOName="Eu2O3/TREO";
	rate=0.8636;
	re=151.96;
	reo=175.96;
	isxtys=TRUE;
	}

ys.Gd={
	Name="Gd";
	ICPName="Gd 310.050";
	RPTOName="Gd2O3";
	SQLName="Gd/TRE";
	SQLOName="Gd2O3/TREO";
	rate=0.8676;
	re=157.25;
	reo=181.25;
	isxtys=TRUE;
	}


ys.Tb={
	Name="Tb";
	ICPName="Tb 332.440";
	RPTOName="Tb4O7";
	SQLName="Tb/TRE";
	SQLOName="Tb4O7/TREO";
	rate=0.8502;
	re=158.93;
	reo=186.93;
	isxtys=TRUE;
	}

ys.Dy={
	Name="Dy";
	ICPName="Dy 353.171";
	RPTOName="Dy2O3";
	SQLName="Dy/TRE";
	SQLOName="Dy2O3/TREO";
	rate=0.8713;
	re=162.5;
	reo=186.5;
	isxtys=TRUE;
	}


ys.Ho={
	Name="Ho";
	ICPName="Ho 341.644";
	RPTOName="Ho2O3";
	SQLName="Ho/TRE";
	SQLOName="Ho2O3/TREO";
	rate=0.873;
	re=164.93;
	reo=188.93;
	isxtys=TRUE;
	}


ys.Er={
	Name="Er";
	ICPName="Er 326.478";
	RPTOName="Er2O3";
	SQLName="Er/TRE";
	SQLOName="Er2O3/TREO";
	rate=0.8715;
	re=167.2;
	reo=191.2;
	isxtys=TRUE;
	}


ys.Tm={
	Name="Tm";
	ICPName="Tm 313.125";
	RPTOName="Tm2O3";
	SQLName="Tm/TRE";
	SQLOName="Tm2O3/TREO";
	rate=0.8756;
	re=168.934;
	reo=192.934;
	isxtys=TRUE;
	}


ys.Yb={
	Name="Yb";
	ICPName="Yb 289.138";
	RPTOName="Yb2O3";
	SQLName="Yb/TRE";
	SQLOName="Yb2O3/TREO";
	rate=0.8782;
	re=173;
	reo=197;
	isxtys=TRUE;
	}


ys.Lu={
	Name="Lu";
	ICPName="Lu 261.541";
	RPTOName="Lu2O3";
	SQLName="Lu/TRE";
	SQLOName="Lu2O3/TREO";
	rate=0.8794;
	re=174.96;
	reo=198.96;
	isxtys=TRUE;
	}


ys.Y={
	Name="Y";
	ICPName="Y 242.219";
	RPTOName="Y2O3";
	SQLName="Y/TRE";
	SQLOName="Y2O3/TREO";
	rate=0.7874;
	re=88.906;
	reo=112.906;
	isxtys=TRUE;
	}


ys.Al={
	Name="Al";
	ICPName="Al 396.152";
	RPTOName="Al2O3";
	SQLName="'铝','Al'";
	SQLOName="'三氧化二铝','Al2O3'";	--自动匹配
	rate=0.5292;
	re=0;
	reo=0;
	isxtys=FALSE;
	RPT="rptal";
	divnum=10;	--需要在程序中除以的系数
	}

ys.Ca={
	Name="Ca";
	ICPName="Ca";
	RPTOName="CaO";
	SQLName="'钙','Ca'";
	SQLOName="'氧化钙','CaO'";
	rate=0.7147;
	re=0;
	reo=0;
	isxtys=FALSE;
	RPT="rptca";
	divnum=1;
}
	
	






