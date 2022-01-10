extends Object
class_name Debug

#STATIC CLASS FOR DEBUGGING
const divide = " --- "

static func Log1(var a):
	print(a)
	pass

static func Log2(var a, var b):
	var strg : String = String(a) + divide + String(b)
	print(strg)
	pass

static func Log3(var a, var b, var c):
	var strg : String = String(a) + divide + String(b) + divide + String(c)
	print(strg)
	pass


