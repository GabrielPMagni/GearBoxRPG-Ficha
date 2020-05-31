<?php
$data = json_decode(file_get_contents("php://input"), true);
if(isset($data) && ($data != null) && isset($data["playerName"]) && isset($data["charName"]) && isset($data["charLife"]) && isset($data["charRace"]) && isset($data["charClass"])){
    try {
        $conn = new PDO("mysql:host=127.0.0.1:3306;dbname=banco_exemplo", "client", "exemplo123");
        $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    } catch (PDOException $e) {
        echo "Erro: " . $e;
    }

    if(!$conn){
        header("Erro na conexão", true, 404);
        echo "<h1>" . $data . "</h1>";
        
    } else {
        try {
            $stmt = $conn->prepare("INSERT INTO TabelaExemplo (player_name, char_name, char_life, char_race, char_class) VALUES (?, ?, ?, ?, ?);");
            $stmt->bindParam(1, $data["playerName"]);
            $stmt->bindParam(2, $data["charName"]);
            $stmt->bindParam(3, $data["charLife"]);
            $stmt->bindParam(4, $data["charRace"]);
            $stmt->bindParam(5, $data["charClass"]);
            $stmt->execute();
        } catch (PDOException $e) {
            echo "Erro INSERT: " . $e;
        }
       
        header("Válido", true, 200);
        echo "No Bugs";
        mysql_close($conn);
    }


}
else {
    header_remove();
    header("Não autorizado", true, 403);
?>

<h1>QuackOS</h1>


<?php
    echo "<h2>" . $data["playerName"] . "</h2>";

}



?>