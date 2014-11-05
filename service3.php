<?php
    header("Content-type: application/json");
    error_reporting(E_ALL);
    ini_set("display_startup_errors", 1);
    ini_set("display_errors", 1);
    
        function _json_encode($val)
        {
            if (is_string($val)) return '"'.addslashes($val).'"';
            if (is_numeric($val)) return $val;
            if ($val === null) return 'null';
            if ($val === true) return 'true';
            if ($val === false) return 'false';
        
            $assoc = false;
            $i = 0;
            foreach ($val as $k=>$v){
                if ($k !== $i++){
                    $assoc = true;
                    break;
                }
            }
            $res = array();
            foreach ($val as $k=>$v){
                $v = _json_encode($v);
                if ($assoc){
                    $k = '"'.addslashes($k).'"';
                    $v = $k.':'.$v;
                }
                $res[] = $v;
            }
            $res = implode(',', $res);
            return ($assoc)? '{'.$res.'}' : '['.$res.']';
        }

    class Service
    {
        public $user = 'highscores';
        public $dbname = 'World';
        public $pass = 'billswebglclass';
        public $host = 'localhost';
        public $dsn = '';
        public $pdo = '';
        public $testMode = TRUE;
        
        
        public function __construct()
        {

            //echo($id);
            session_start();
            $this->dsn = sprintf('mysql:dbname=%s;host=%s', $this->dbname, $this->host);
            $this->pdo = new PDO($this->dsn, $this->user, $this->pass);
            
            if($this->testMode)
            {
                $this->pdo = new PDO($this->dsn, $this->user, $this->pass, array(PDO::ATTR_ERRMODE => PDO::ERRMODE_WARNING));
            } else {
                $this->pdo = new PDO($this->dsn, $this->user, $this->pass);
            }
            
			
			$sql = "SELECT * FROM `Country`";
            
            $stamt = $this->pdo->prepare($sql);
            $stamt->execute();
            
            $tempArray = array();
            $resultsArray = array();
            
             while($row = $stamt->fetch(PDO::FETCH_ASSOC))
             {
                //$this->scoredata[] = $row;
                $tempArray = $row;
                array_push($resultsArray, $tempArray);
             }

            echo(_json_encode($resultsArray));
            $dbh = NULL;
            
        }
        

        

        
    }
    
    $s = new Service();
    