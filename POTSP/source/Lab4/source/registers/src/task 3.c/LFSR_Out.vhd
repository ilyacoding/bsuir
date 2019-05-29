library ieee;
use ieee.std_logic_1164.all;

-- 3.15

entity LFSR_Out is
	generic (				  
		N : integer := 4;
		init_state : std_logic_vector := "1111"
		);	
	port(
		CLK: in std_logic;
		RST: in std_logic;		
		State: out std_logic_vector(0 to N-1);
		Pout: out std_logic
		);	 
	
end LFSR_Out;

architecture beh of LFSR_Out is	
	signal register_state: std_logic_vector(0 to N-1) := init_state;	
Begin
	Main: process (CLK, RST)
	begin
		if RST = '1' then
			register_state <= init_state;
		elsif rising_edge(CLK) then			
			register_state <= (register_state(0) xor register_state(N-1)) & register_state(0 to N-2);
		end if;
	end process;	
	
	Pout <= register_state(N-1);
	State <= register_state;
	
End Beh;