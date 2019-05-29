library IEEE;
use IEEE.STD_LOGIC_1164.all;

entity RSFF is
	port(
		R : in STD_LOGIC;
		S : in STD_LOGIC;
		CLK : in STD_LOGIC;	
		Q : out STD_LOGIC
		);
end RSFF;

architecture beh of RSFF is
	signal result: STD_LOGIC;
begin
	process(R, S, CLK)
	begin
		if rising_edge(CLK) then
			if (R = '1' and S = '1') then
				result <= 'Z';
			elsif R = '1' then
				result <= '0';
			elsif S = '1' then
				result <= '1';
			end if; 
		end if;
	end process; 
	
	Q <= result;
end beh;
