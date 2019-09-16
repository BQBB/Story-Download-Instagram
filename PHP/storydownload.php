<?php
set_time_limit(0);
/////////// Check Request Method
if($_SERVER['REQUEST_METHOD']=='GET' and isset($_GET['user']))
{
	$path= file_exists('Dstory');
	if($path){work($_GET['user']);}
	else{mkdir('Dstory');work($_GET['user']);}
	
		
	
	
	
}

///////// Get ID user To Start Our Mission
function getid($user)
{
	$result=file_get_contents('https://www.instagram.com/'.$user);
	preg_match('/"profilePage_(\d+)",/',$result,$out);
	return $out[1];
}
////// Get URLs From ID OF user 
function fillter($id)
{
	$result=file_get_contents('http://mrvirus.cf/StoryDownload.php?id='.$id);
	preg_match_all('/{URL:(.*?)}/',$result,$out);
	return $out[1];
}
/////// Download Videos And Photos
function download($user,$url,$count)
{
	$result=file_get_contents($url);
	if(stristr($result,'mp4'))
		{
		 $down=fopen('Dstory\\'.$user.$count.'.mp4','wb');
		 fwrite($down, $result);
		 fclose($down);
		 sleep(1);
		}
	else{
		 $down=fopen('Dstory\\'.$user.$count.'.jpg','wb');
		 fwrite($down, $result);
		 fclose($down);
		 sleep(1);
		}
}
//// Work Function To Do our Thins From scratch
function work($user)
{
$ids=getid($user);
$listURL=fillter($ids);

$count =0;
foreach($listURL as $url){
download($user,$url,$count);
$count =$count+1;
}
echo "Finished..";
}

?>