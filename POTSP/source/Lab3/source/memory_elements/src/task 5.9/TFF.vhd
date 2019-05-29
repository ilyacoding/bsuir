library IEEE;
use IEEE.std_logic_1164.all;

entity TFF is
	port(
		T : in std_logic;		
		CLK : in std_logic;	
		Q : out std_logic;
		CLR : in std_logic
		);
end TFF;

architecture beh of TFF is
	signal s: std_logic;
begin
	process(T, CLK, CLR)
	begin
		if CLR = '1' then
			s <= '0';
		elsif T = '1' then
			if rising_edge(CLK) then
				s <= not s;	 
			end if;
		end if;
	end process; 
	
	Q <= s;
end beh;
