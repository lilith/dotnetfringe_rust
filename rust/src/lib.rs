#[cfg(test)]
mod tests {
    #[test]
    fn it_works() {
      assert!(::in_portland());
    }
}


#[no_mangle]
pub extern "C" fn in_portland() -> bool {
    return true;
}


#[no_mangle]
pub extern "C" fn rust_factorial(n: i64) -> i64 {
    let mut val = 1;
    for factor in 2..(n+1) {
      val *= factor;
    }
    return val;
}
