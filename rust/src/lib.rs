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
