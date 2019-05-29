library IEEE;
use IEEE.std_logic_1164.all;

entity FDCPE is
	port(
		CLR : in std_logic;
		PRE : in std_logic;
		D : in std_logic;
		E : in std_logic;
		CLK : in std_logic;	
		Q : out std_logic
		);
end FDCPE;

architecture beh of FDCPE is
	signal s: std_logic;
begin
	process(CLR, PRE, D, E, CLK)
	begin
		if CLR = '1' then
			s <= '0';
		elsif PRE = '1' then
			s <= '1';
		elsif E = '1' then
			if rising_edge(CLK) then
				s <= D;	 
			end if;
		end if;
	end process; 
	
	Q <= s;
end beh;
