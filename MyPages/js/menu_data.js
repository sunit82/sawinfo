fixMozillaZIndex=true; //Fixes Z-Index problem  with Mozilla browsers but causes odd scrolling problem, toggle to see if it helps
_menuCloseDelay=500;
_menuOpenDelay=150;
_subOffsetTop=2;
_subOffsetLeft=-2;




with(menuStyle=new mm_style()){
bordercolor="#999999";
borderstyle="solid";
borderwidth=1;
fontfamily="Verdana, Tahoma, Arial";
fontsize="75%";
fontstyle="normal";
headerbgcolor="#ffffff";
headercolor="#000000";
offbgcolor="#eeeeee";
offcolor="#000000";
onbgcolor = "#9FB0BE";
oncolor="#000099";
outfilter="randomdissolve(duration=0.3)";
overfilter="Fade(duration=0.2);Alpha(opacity=90);Shadow(color=#777777', Direction=135, Strength=3)";
padding=4;
pagebgcolor = "#5B82A3";
pagecolor="black";
separatorcolor="#999999";
separatorsize=1;
subimage = $Url.resolve('~/images/arrow.gif'); 
subimagepadding=2;
}

with(milonic=new menuname("Main Menu")){
alwaysvisible=1;
orientation="horizontal";
style=menuStyle;
aI("text=Home;url=" + $Url.resolve('~/Default.aspx'));
aI("showmenu=Applications;text=Applications;");
aI("showmenu=MyPages;text=SAWINFO;");
aI("text=Contact Us;url=" + $Url.resolve('~/Contact.aspx'));
}

with(milonic=new menuname("Applications")){
overflow="scroll";
style=menuStyle;
aI("text=SAWManager;url=http://www.sawinfotech.com/SAWManager;");
aI("text=SAWWiki;url=http://www.sawinfotech.com/SAWWiki;");
aI("text=Waingankars;url=http://www.sawinfotech.com/Waingankars;");
aI("text=SAWMail;url=http://webmail.sawinfotech.com;");
aI("text=SAWCMS;url=" + $Url.resolve('~/CMSList.aspx'));
aI("text=cPanel;url=http://www.sawinfotech.com/cPanel;");

}

with(milonic=new menuname("MyPages")){
style=menuStyle;
aI("text=Profile;url=" + $Url.resolve('~/SAWINFO/Profile.aspx'));
aI("text=Photos;url=" + $Url.resolve('~/SAWINFO/Photos.aspx'));
aI("text=Technovations;url=" + $Url.resolve('~/SAWINFO/Technovations.aspx'));
aI("text=IT2Danger;url=" + $Url.resolve('~/IT2Danger.htm'));
}


drawMenus();

