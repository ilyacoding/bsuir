<?php
if (is_numeric($argv[1]))
{
	for($i = 2; $i <= 16; $i++) { 
		print($i . ": " . base_convert(abs($argv[1]), 10, $i) . "\n"); 
	}
} else {
	echo "Bad arguments";
}