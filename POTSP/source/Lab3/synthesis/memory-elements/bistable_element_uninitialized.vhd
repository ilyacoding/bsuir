library IEEE;
use IEEE.STD_LOGIC_1164.all;

entity BistableElement is
	port(
		Q : out STD_LOGIC;
		nQ : out STD_LOGIC
		);
end BistableElement;

architecture uninitialized of BistableElement is
	component inv
		port (
			a: in std_logic;
			nA: out std_logic
			);
	end component;
	signal t1: std_logic;  
	signal t2: std_logic;
begin	
	U1: inv port map (a => t2, nA => t1);
	U2: inv port map (a => t1, nA => t2);	  
	nQ <= t1;
	Q <= t2;
end uninitialized;