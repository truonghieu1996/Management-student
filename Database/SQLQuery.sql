GO	
CREATE DATABASE QuanLyHocVien
USE QuanLyHocVien
GO	
CREATE TABLE HocVien
(
	idHV INT IDENTITY PRIMARY KEY,
	holot NVARCHAR(100) NOT NULL,
	ten NVARCHAR(50) NOT NULL,
	ngaysinh DATE NOT NULL,
	sdt VARCHAR(12) NOT NULL,
	diachi NVARCHAR(300) NOT NULL,
	gioitinh NVARCHAR(3) NOT NULL,
	ghichu NVARCHAR(255),
	ngaynhap DATE NOT NULL,	
	ngayhocthu DATE NOT NULL,
	
)
CREATE TABLE KetQuaHoc
(
	idKQ INT IDENTITY PRIMARY KEY,
	tinhtranghocthu NVARCHAR(1000) NOT NULL,
	ketquakiemtra FLOAT NOT NULL,
	idHV INT 
	FOREIGN KEY (idHV) REFERENCES dbo.HocVien(idHV)
)
GO
GO
INSERT INTO dbo.HocVien
        (
          holot ,
          ten ,
          ngaysinh ,
          sdt ,
          diachi ,
          gioitinh ,
          ghichu ,
          ngaynhap ,
          ngayhocthu
        )
VALUES  (
          N'Nguyễn Văn' , -- holot - nvarchar(100)
          N'An' , -- ten - nvarchar(50)
          GETDATE() , -- ngaysinh - date
          '0907049783' , -- sdt - varchar(12)
          N'Long Xuyên' , -- diachi - nvarchar(300)
          N'Nam' , -- gioitinh - nvarchar(3)
          N'Không có ghi chú' , -- ghichu - nvarchar(255)
          GETDATE() , -- ngaynhap - date
          GETDATE()  -- ngayhocthu - date
        )
INSERT INTO dbo.HocVien
        (
          holot ,
          ten ,
          ngaysinh ,
          sdt ,
          diachi ,
          gioitinh ,
          ghichu ,
          ngaynhap ,
          ngayhocthu
        )
VALUES  (
          N'Trần Ngọc Thùy' , -- holot - nvarchar(100)
          N'Linh' , -- ten - nvarchar(50)
          GETDATE() , -- ngaysinh - date
          '01689777912' , -- sdt - varchar(12)
          N'An Gang' , -- diachi - nvarchar(300)
          N'Nữ' , -- gioitinh - nvarchar(3)
          N'Không có ghi chú' , -- ghichu - nvarchar(255)
          GETDATE() , -- ngaynhap - date
          GETDATE()  -- ngayhocthu - date
        )
GO	
GO
INSERT INTO dbo.KetQuaHoc
        (
          tinhtranghocthu ,
          ketquakiemtra ,
          idHV
        )
VALUES  (
          N'Tốt' , -- tinhtranghocthu - nvarchar(1000)
          8.3 , -- ketquakiemtra - float
          1  -- idHV - int
        )
INSERT INTO dbo.KetQuaHoc
        (
          tinhtranghocthu ,
          ketquakiemtra ,
          idHV
        )
VALUES  (
          N'Tốt' , -- tinhtranghocthu - nvarchar(1000)
          9.0 , -- ketquakiemtra - float
          2  -- idHV - int
        )
GO

GO
CREATE PROC USP_GetTableKetQuaByID
@idHV INT 
AS
BEGIN
	SELECT * FROM dbo.KetQuaHoc WHERE idHV = @idHV
END 
GO
GO
ALTER FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) 
RETURNS NVARCHAR(4000) 
AS 
BEGIN 
IF @strInput IS NULL 
RETURN @strInput IF @strInput = '' 
RETURN @strInput 
DECLARE @RT NVARCHAR(4000) 
DECLARE @SIGN_CHARS NCHAR(136) 
DECLARE @UNSIGN_CHARS NCHAR (136) 
SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' 
DECLARE @COUNTER int 
DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) 
BEGIN 
IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput 
END
GO
CREATE PROC USP_DeleteHocVienByID
@idHV INT	
AS
BEGIN
	DELETE dbo.KetQuaHoc WHERE idHV = @idHV
	DELETE dbo.HocVien WHERE idHV = @idHV
END
GO
CREATE PROC USP_getKetQuaHocVienByIdHV
@idhv INT 
AS
BEGIN
SELECT hv.holot , hv.ten , hv.ngaysinh , hv. sdt , hv.diachi , hv.gioitinh , kq.tinhtranghocthu, kq.ketquakiemtra
FROM dbo.HocVien hv, dbo.KetQuaHoc kq
WHERE hv.idHV = kq.idHV AND hv.idHV = @idhv
END 
GO