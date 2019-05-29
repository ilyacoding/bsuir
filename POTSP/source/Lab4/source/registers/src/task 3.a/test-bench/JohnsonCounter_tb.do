SetActiveLib -work
comp -include "$dsn\src\task 3.a\JohnsonCounter.vhd" 
comp -include "$dsn\src\task 3.a\test-bench\JohnsonCounter_TB.vhd" 
asim +access +r JohnsonCounter_tb 

wave
wave -noreg CLK
wave -noreg RST
wave -noreg -bin Pout		  

run 1us
# The following lines can be used for timing simulation
# acom <backannotated_vhdl_file_name>
# comp -include "$dsn\src\TestBench\shiftregister_TB_tim_cfg.vhd" 
# asim +access +r TIMING_FOR_shiftregister 
