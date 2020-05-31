<?php
if(isset($_POST[nome])){
    $db = "127.0.0.1:3306";
    $user = "client";
    $pass = "example123";
    $conn = mysql_connect($db, $user, $pass);
    
    if(!$conn){
        die("Erro de conexão #001" . mysql_error());
    } else {
        $sql = "INSERT INTO TabelaExemplo (exemplo_nome) VALUES (\"" . $_POST[nome] . "\");";
        $retorno = mysql_query($sql, $conn);
        if(!$retorno){
            die("Erro na inserção #001" . mysql_error());
        }
        echo "No Bugs";
        mysql_close($conn);
    }


}
else {
?>



<?php
}



?>