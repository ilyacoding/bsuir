SetActiveLib -work
comp -dbg -include "$dsn\src\task 3.b\LFSR_In.vhd"
comp -dbg -include "$dsn\src\task 3.b\test-bench\LFSR_In_tb.vhd"
asim +access +r LFSR_In_tb 

wave
wave -noreg CLK
wave -noreg RST
wave -noreg Pout		  
wave -noreg -bin -reverseorder State

run 1us    
# The following lines can be used for timing simulation
# acom <backannotated_vhdl_file_name>
# comp -include "$dsn\src\TestBench\shiftregister_TB_tim_cfg.vhd" 
# asim +access +r TIMING_FOR_shiftregister 
