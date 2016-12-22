<?
// =============================================================================
$host = "localhost"; //put your host here
$user = "root"; //in general is root
$password = ""; //use your password here
$dbname = "accounts"; //your database
// =============================================================================


// PROTECT AGAINST SQL INJECTION and CONVERT PASSWORD INTO MD5 formats
function anti_injection_login_senha($sql, $formUse = true)
{
$sql = preg_replace("/(from|select|insert|delete|where|drop table|show tables|,|'|#|\*|--|\\\\)/i","",$sql);
$sql = trim($sql);
$sql = strip_tags($sql);
if(!$formUse || !get_magic_quotes_gpc())
  $sql = addslashes($sql);
  $sql = md5(trim($sql));
return $sql;
}
// THIS ONE IS JUST FOR THE NICKNAME PROTECTION AGAINST SQL INJECTION
function anti_injection_login($sql, $formUse = true)
{
$sql = preg_replace("/(from|select|insert|delete|where|drop table|show tables|,|'|#|\*|--|\\\\)/i","",$sql);
$sql = trim($sql);
$sql = strip_tags($sql);
if(!$formUse || !get_magic_quotes_gpc())
  $sql = addslashes($sql);
return $sql;
}
// =============================================================================
$unityHash = anti_injection_login($_POST["myform_hash"]);
$phpHash = "99873123545987"; // same code in here as in your Unity game
 
$nick = anti_injection_login($_POST["myform_nick"]); //I use that function to protect against SQL injection
$pass = anti_injection_login_senha($_POST["myform_pass"]);
$email = $_POST["myform_pass"];
$login = $_POST["myform_login"];
/*
you can also use this:
$nick = $_POST["myform_nick"];
$pass = $_POST["myform_pass"];
*/


if(!$nick || !$pass || !$email) {
    echo "Fields can't be empty.";
} else {
    if ($unityHash != $phpHash){
        echo "Security verification unsuccessful.";
    } 
    if($login == 0) //REGISTER
    {
    
    $SQL = "INSERT INTO `accounts´('name', 'email', 'password') VALUES($nick, $email, $password);
    $result_id = @mysql_query($SQL) or die("DATABASE ERROR!");
    
    } else //LOGIN
    {
        $SQL = "SELECT * FROM accounts WHERE email = '" . $email . "'";
        $result_id = @mysql_query($SQL) or die("DATABASE ERROR!");
        $total = mysql_num_rows($result_id);
        if($total) {
            $datas = @mysql_fetch_array($result_id);
            if(!strcmp($pass, $datas["password"])) {
                echo "Success!";
            } else {
                echo "Invalid email or password.";
            }
        } else {
            echo "Data invalid - cant find name.";
        }
    }
}
// Close mySQL Connection
mysql_close();
?>