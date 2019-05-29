SetActiveLib -work
comp -include "$dsn\src\task 3.d\Signature.vhd"
comp -include "$dsn\src\task 3.d\test-bench\Signature_tb.vhd"
asim +access +r Signature_tb 

wave
wave -noreg CLK
wave -noreg RST
wave -noreg Pout		
wave -noreg Pin
wave -noreg -bin State

run 170ns    
# The following lines can be used for timing simulation
# acom <backannotated_vhdl_file_name>
# comp -include "$dsn\src\TestBench\shiftregister_TB_tim_cfg.vhd" 
# asim +access +r TIMING_FOR_shiftregister 
