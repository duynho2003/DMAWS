CREATE TABLE tbAccount
(      
    [no] varchar(50) PRIMARY KEY,
    pincode int,
)
GO

CREATE TABLE tbTransaction
(
    id INTEGER PRIMARY KEY IDENTITY(1,1),
    trandate VARCHAR(50),
	deposit decimal(15,2),
	withdraw decimal(15,2),
	balance decimal(15,2),
	[no] varchar(50),

	FOREIGN KEY ([no]) REFERENCES tbAccount ([no]),
);
GO
----
select * from tbTransaction where [no]='A202302'