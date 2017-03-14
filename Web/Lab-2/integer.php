<?php
for($i = 2; $i <= 16; $i++) { 
	print(base_convert(abs($argv[1]), 10, $i) . "\n"); 
}