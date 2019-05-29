library ieee;
use ieee.std_logic_1164.all;
-- v. 15 
entity task3_1 is
	port(        					
		G_L, A, B: in std_logic; 
		Y0, Y1, Y2, Y3: out std_logic
		); 
end task3_1;

architecture struct of task3_1 is
	
	component nand3
		port(        					
			A, B, C: in std_logic; 
			R: out std_logic
			);	
	end component;
	
	component inv
		port(
			A: in std_logic;
			nA: out std_logic
			);
	end component;
	
	signal nG_L, nA, nB: std_logic;
begin						  
	U1: inv port map(G_L, nG_L);
	U2: inv port map(A, nA);
	U3: inv port map(B, nB);
	U4: nand3 port map(nA, nB, nG_L, Y0);
	U5: nand3 port map(nG_L, nB, A, Y1);
	U6: nand3 port map(nG_L, nA, B, Y2);
	U7: nand3 port map(nG_L, A, B, Y3);
end struct;

architecture beh of task3_1 is
begin
	Y0 <= not ((not A) and (not B) and (not G_L));
	Y1 <= not ((not G_L) and (not B) and A);
	Y2 <= not ((not G_L) and (not A) and B);
	Y3 <= not ((not G_L) and A and B);
end beh;