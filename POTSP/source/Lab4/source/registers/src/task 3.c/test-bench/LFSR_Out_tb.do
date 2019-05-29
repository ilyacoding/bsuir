SetActiveLib -work
comp -include "$dsn\src\task 3.c\LFSR_Out.vhd"
comp -include "$dsn\src\task 3.c\test-bench\LFSR_Out_tb.vhd"
asim +access +r LFSR_Out_tb 

wave
wave -noreg CLK
wave -noreg RST
wave -noreg Pout		  
wave -noreg -bin State

run 1us    
# The following lines can be used for timing simulation
# acom <backannotated_vhdl_file_name>
# comp -include "$dsn\src\TestBench\shiftregister_TB_tim_cfg.vhd" 
# asim +access +r TIMING_FOR_shiftregister 
