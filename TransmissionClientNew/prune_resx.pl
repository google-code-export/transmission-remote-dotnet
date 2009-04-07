#!/usr/bin/perl -w
use strict;

my $skip = 0;
my $output = "";
open(RESX, "<$ARGV[0]");
while(<RESX>)
{
	if ($skip > 0)
	{
		if ($_ =~ m/\<\/data\>/)
		{
			$skip = 0;
		}
		next;
	}
	if (m/\<data name=\"(.*?)\"/)
	{
		if ($1 !~ m/\.(Text|Item\d+)$/)
		{
			$skip = 1;
			next;
		}
	}
	$output .= $_;
	#print $_;
}
close(RESX);

open(RESX, ">$ARGV[0]");
print RESX $output;
close(RESX);
